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
    ///     Implementação da <see cref="ICargoAppService"/>.
    /// </summary>
    public class CargoAppService : BaseAppService<CargoViewModel, CargoFilter, Cargo>, ICargoAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CargoAppService"/> class.
        ///     Construtor padrão de <see cref="CargoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cargo. Veja <see cref="ICargoRepository"/>.
        /// </param>
        public CargoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ICargoRepository repository)
            : base(uow, mapper, repository)
        {
        }

        public override Expression<Func<Cargo, bool>> Filter(CargoFilter filter)
        {
            var expression = base.Filter(filter);

            if (filter != null)
            {
                if (filter.IdCargo.HasValue)
                {
                    expression = expression.And(f => f.IdCargo == filter.IdCargo.Value);
                }

                if (!string.IsNullOrEmpty(filter.DescricaoCargo))
                {
                    expression = expression.And(f => f.DescricaoCargo.ToLowerCase().Contains(filter.DescricaoCargo.ToLowerCase()));
                }
            }

            return expression;
        }

        public override Func<Cargo, object> OrderBy(CargoFilter filter)
        {
            var orderBy = base.OrderBy(filter);

            switch (filter.SortBy.ToLower())
            {
                case "id":
                    orderBy = (x => x.IdCargo);
                    break;
                case "descricaocargo":
                    orderBy = (x => x.DescricaoCargo);
                    break;
                default:
                    orderBy = (x => x.IdCargo);
                    break;
            }

            return orderBy;
        }
    }
}
