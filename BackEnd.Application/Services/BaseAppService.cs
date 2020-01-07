namespace BackEnd.Application.Services
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.Pagers;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Enumerators;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Interfaces;
    using BackEnd.Infra.Utils.Builders;
    using BackEnd.Infra.Utils.Messages;
    using global::AutoMapper;
    using global::AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public abstract class BaseAppService<TViewModel, TFilter, TEntity> : IBaseAppService<TViewModel, TFilter, TEntity>
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
        where TEntity : BaseEntity
    {
        protected readonly IMapper mapper;
        protected readonly IUnitOfWork uow;
        protected readonly IBaseRepository<TEntity> repository;

        public BaseAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IBaseRepository<TEntity> repository)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.repository = repository;
        }

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        /// <returns>
        ///     Todos os registros do banco de dados.
        /// </returns>
        public virtual IEnumerable<TViewModel> GetAll()
        {
            var results = this.repository.GetAll();
            return results.ProjectTo<TViewModel>();
        }

        /// <summary>
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        public virtual TViewModel GetById(int id)
        {
            var result = this.repository.GetById(id);
            return this.mapper.Map<TViewModel>(result);
        }

        /// <summary>
        ///     Obtém os registros utilizando o filtro utilizado no parâmetro.
        /// </summary>
        public virtual ResponseViewModel GetBy(TFilter filter, params Expression<Func<TEntity, object>>[] includes)
        {
            var expression = this.Filter(filter);
            var orderBy = this.OrderBy(filter);

            var orderByDirection = OrderByDirectionEnum.Ascending;
            if (filter.SortDirection.ToLowerCase() == "desc")
            {
                orderByDirection = OrderByDirectionEnum.Descending;
            }

            #region Pager

            var pager = new Pager(filter);

            #endregion Pager

            var query = this.repository.GetBy(expression, includes);
            var results = this.repository.GetByPaged(query, orderBy, orderByDirection, pager).ToList();

            var totalItems = this.repository.Count(expression);
            var totalPages = 1;
            if (filter.HasPagination)
            {
                if (filter.PageSize.HasValue)
                {
                    var ceilingResult = Math.Ceiling((decimal)totalItems / (decimal)filter.PageSize.Value);
                    totalPages = int.Parse(ceilingResult.ToString());
                }
            }

            var data = this.mapper.Map<IEnumerable<TViewModel>>(results);
            this.mapper.Map(filter, data);

            var response = new ResponseViewModel
            {
                Data = data,
                Page = new PageViewModel
                {
                    PageNumber = filter.HasPagination ? (filter.PageNumber ?? 1) : 1,
                    Size = filter.HasPagination ? (filter.PageSize ?? totalItems) : totalItems,
                    TotalElements = totalItems,
                    TotalPages = totalPages
                },
                Success = true
            };

            return response;
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public virtual IEnumerable<TViewModel> GetBy(Expression<Func<TEntity, bool>> expression)
        {
            var results = this.repository.GetBy(expression).AsNoTracking().ToList();
            return this.mapper.Map<IEnumerable<TViewModel>>(results);
        }

        /// <summary>
        ///     Obtém os registros utilizando a expressão utilizada no parâmetro.
        /// </summary>
        public virtual IEnumerable<TViewModel> GetBy(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var results = this.repository.GetBy(expression, includes).ToList();
            return this.mapper.Map<IEnumerable<TViewModel>>(results);
        }


        /// <summary>
        ///     Salva o registro passado como parâmetro.
        /// </summary>
        public virtual TViewModel Add(TViewModel model, bool commit = true)
        {
            this.Validate(model);

            var entity = this.mapper.Map<TEntity>(model);
            this.repository.Add(entity);

            this.Commit(commit);

            return model;
        }

        /// <summary>
        ///     Atualiza o registro passado como parâmetro.
        /// </summary>
        public virtual void Update(TViewModel model, bool commit = true)
        {
            this.Validate(model);

            if (model.Id == 0)
            {
                throw new BackEndException(Messages.NotFound);
            }

            var entityDb = this.repository.GetById(model.Id);
            if (entityDb == null)
            {
                throw new BackEndException(Messages.NotFound);
            }

            var entity = this.mapper.Map<TEntity>(model);
            this.repository.Update(entity);
            this.Commit(commit);
        }

        /// <summary>
        ///     Remove o registro que possui o identificador passado no parâmetro.
        /// </summary>
        public virtual void Remove(int id, bool commit = true)
        {
            var entity = this.repository.GetById(id);
            if (entity == null)
            {
                throw new BackEndException(Messages.NotFound);
            }

            this.repository.Remove(id);
            this.Commit(commit);
        }

        /// <summary>
        ///     Remove a lista de registros possuem o identificador passado no parâmetro.
        /// </summary>
        public virtual void Remove(IEnumerable<int> ids, bool commit = true)
        {
            if (ids != null)
            {
                foreach (var id in ids)
                {
                    this.Remove(id, false);
                }
            }

            this.Commit(commit);
        }

        public virtual Expression<Func<TEntity, bool>> Filter(TFilter filter)
        {
            var expression = PredicateBuilder.True<TEntity>();

            if (filter != null)
            {
                if (!string.IsNullOrEmpty(filter.Search))
                {
                    var searchExpression = PredicateBuilder.False<TEntity>();

                    var properties = typeof(TEntity).GetProperties();
                    foreach (var property in properties)
                    {
                        searchExpression = searchExpression.Or(f => property.GetValue(f).ToString() == filter.Search);
                    }

                    expression = expression.And(searchExpression);
                }
            }

            return expression;
        }

        public virtual Func<TEntity, object> OrderBy(TFilter filter)
        {
            Func<TEntity, object> orderBy;

            switch (filter.SortBy.ToLower())
            {
                //case "ativo":
                //    orderBy = (x => x.Ativo);
                //    break;
                default:
                    orderBy = (x => 1);
                    break;
            }

            return orderBy;
        }

        public virtual void Validate(TViewModel model)
        {
            if (model == null)
            {
                throw new BackEndException(Messages.EmptyData);
            }
        }

        public virtual void Commit(bool commit)
        {
            if (commit)
            {
                this.uow.Commit();
            }
        }

        /// <summary>
        ///     Desaloca os recursos de Cidade Application Service usando o Garbage Collector.
        /// </summary>
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
