namespace BackEnd.Application.Services
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Interfaces;
    using global::AutoMapper;

    /// <summary>
    ///     Implementação da <see cref="ISituacaoAppService"/>.
    /// </summary>
    public class SituacaoAppService : BaseAppService<SituacaoViewModel, SituacaoFilter, Situacao>, ISituacaoAppService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SituacaoAppService"/> class.
        ///     Construtor padrão de <see cref="SituacaoAppService"/>.
        /// </summary>
        /// <param name="uow">
        ///     Contrato do Unit of Work. Veja <see cref="IUnitOfWork"/>.
        /// </param>
        /// <param name="mapper">
        ///     Contrato do AutoMapper. Veja <see cref="IMapper"/>.
        /// </param>
        /// <param name="repository">
        ///     O repositório da entidade Cargo. Veja <see cref="ISituacaoRepository"/>.
        /// </param>
        public SituacaoAppService(
            IUnitOfWork uow,
            IMapper mapper,
            ISituacaoRepository repository)
            : base(uow, mapper, repository)
        {
        }
    }
}
