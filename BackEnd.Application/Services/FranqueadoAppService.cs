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
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     Implementação da <see cref="IFranqueadoAppService"/>.
    /// </summary>
    public class FranqueadoAppService : BaseAppService<FranqueadoViewModel, FranqueadoFilter, Franqueado>, IFranqueadoAppService
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
        ///     O repositório da entidade Cargo. Veja <see cref="IFranqueadoRepository"/>.
        /// </param>
        public FranqueadoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IFranqueadoRepository repository)
            : base(uow, mapper, repository)
        {
        }

        /// <summary>
        ///     Obtém o registro cujo ID é o passado como parâmetro.
        /// </summary>
        public override FranqueadoViewModel GetById(int id)
        {
            var result = this.repository.GetBy(franqueado => 
                                            franqueado.IdFranqueado == id,
                                            "IdSituacaoNavigation", "Funcionario")
                                        .FirstOrDefault();

            return this.mapper.Map<FranqueadoViewModel>(result);
        }

        public override Expression<Func<Franqueado, bool>> Filter(FranqueadoFilter filter)
        {
            var expression = base.Filter(filter);

            if (filter != null)
            {
                if (filter.IdFranqueado.HasValue)
                {
                    expression = expression.And(f => f.IdFranqueado == filter.IdFranqueado.Value);
                }

                if (filter.IdSituacao.HasValue)
                {
                    expression = expression.And(f => f.IdSituacao == filter.IdSituacao.Value);
                }

                if (!string.IsNullOrEmpty(filter.DescricaoSituacao))
                {
                    expression = expression.And(f => f.IdSituacaoNavigation.DescricaoSituacao.ToLowerCase().Contains(filter.DescricaoSituacao.ToLowerCase()));
                }

                if (filter.IdFuncionario.HasValue)
                {
                    expression = expression.And(f => f.Funcionario.Any(x => x.IdFuncionario == filter.IdFuncionario.Value));
                }

                if (!string.IsNullOrEmpty(filter.DescricaoFuncionario))
                {
                    expression = expression.And(f => f.Funcionario.Any(x => x.DescricaoFuncionario.ToLowerCase().Contains(filter.DescricaoFuncionario.ToLowerCase())));
                }

                if (!string.IsNullOrEmpty(filter.DescricaoFranqueado))
                {
                    expression = expression.And(f => f.DescricaoFranqueado.ToLowerCase().Contains(filter.DescricaoFranqueado.ToLowerCase()));
                }

                if (!string.IsNullOrEmpty(filter.NomeFantasia))
                {
                    expression = expression.And(f => f.NomeFantasia.ToLowerCase().Contains(filter.NomeFantasia.ToLowerCase()));
                }

                if (!string.IsNullOrEmpty(filter.Cnpj))
                {
                    expression = expression.And(f => f.Cnpj.ReplaceNonDigits().Contains(filter.Cnpj.ReplaceNonDigits()));
                }

                if (!string.IsNullOrEmpty(filter.Cpf))
                {
                    expression = expression.And(f => f.Cpf.ReplaceNonDigits().Contains(filter.Cpf.ReplaceNonDigits()));
                }

                if (filter.DataCancelamento.HasValue)
                {
                    expression = expression.And(f => f.DataCancelamento == filter.DataCancelamento.Value);
                }

                if (filter.DataCadastro.HasValue)
                {
                    expression = expression.And(f => f.DataCadastro == filter.DataCadastro.Value);
                }
            }

            return expression;
        }

        public override Func<Franqueado, object> OrderBy(FranqueadoFilter filter)
        {
            var orderBy = base.OrderBy(filter);

            switch (filter.SortBy.ToLower())
            {
                case "id":
                    orderBy = (x => x.IdFranqueado);
                    break;
                case "descricaofranqueado":
                    orderBy = (x => x.DescricaoFranqueado);
                    break;
                default:
                    orderBy = (x => x.IdFranqueado);
                    break;
            }

            return orderBy;
        }
    }
}
