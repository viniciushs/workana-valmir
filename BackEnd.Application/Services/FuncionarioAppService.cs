namespace BackEnd.Application.Services
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Interfaces;
    using global::AutoMapper;

    /// <summary>
    ///     Implementação da <see cref="IFuncionarioAppService"/>.
    /// </summary>
    public class FuncionarioAppService : BaseAppService<FuncionarioViewModel, FuncionarioFilter, Funcionario>, IFuncionarioAppService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FuncionarioAppService"/> class.
        ///     Construtor padrão de <see cref="FuncionarioAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cargo. Veja <see cref="IFuncionarioRepository"/>.
        /// </param>
        public FuncionarioAppService(
            IUnitOfWork uow,
            IMapper mapper,
            IFuncionarioRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
