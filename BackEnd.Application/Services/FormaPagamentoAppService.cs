namespace BackEnd.Application.Services
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Interfaces;
    using BackEnd.Infra.Utils.Builders;
    using global::AutoMapper;
    using System;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implementação da <see cref="IFormaPagamentoAppService"/>.
    /// </summary>
    public class FormaPagamentoAppService : BaseAppService<FormaPagamentoViewModel, FormaPagamentoFilter, FormaPagto>, IFormaPagamentoAppService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FormaPagamentoAppService"/> class.
        ///     Construtor padrão de <see cref="FormaPagamentoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cargo. Veja <see cref="IFormaPagamentoRepository"/>.
        /// </param>
        public FormaPagamentoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IFormaPagamentoRepository repository)
            : base(uow, mapper, repository)
        {
        }

        public override Expression<Func<FormaPagto, bool>> Filter(FormaPagamentoFilter filter)
        {
            var expression = base.Filter(filter);

            if (filter != null)
            {
                if (filter.IdFormaPagto.HasValue)
                {
                    expression = expression.And(f => f.IdFormaPagto == filter.IdFormaPagto.Value);
                }

                if (!string.IsNullOrEmpty(filter.DescricaoFormaPagto))
                {
                    expression = expression.And(f => f.DescricaoFormaPagto.ToLowerCase().Contains(filter.DescricaoFormaPagto.ToLowerCase()));
                }
            }

            return expression;
        }

        public override Func<FormaPagto, object> OrderBy(FormaPagamentoFilter filter)
        {
            var orderBy = base.OrderBy(filter);

            switch (filter.SortBy.ToLower())
            {
                case "id":
                    orderBy = (x => x.IdFormaPagto);
                    break;
                case "descricaoformapagto":
                    orderBy = (x => x.DescricaoFormaPagto);
                    break;
                default:
                    orderBy = (x => x.IdFormaPagto);
                    break;
            }

            return orderBy;
        }
    }
}
