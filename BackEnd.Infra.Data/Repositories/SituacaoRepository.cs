namespace BackEnd.Infra.Data.Repositories
{
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;

    /// <summary>
    ///     Implementação da <see cref="ISituacaoRepository"/>.
    /// </summary>
    public class SituacaoRepository : BaseRepository<Situacao>, ISituacaoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SituacaoRepository"/> class.
        ///     Construtor padrão de <see cref="SituacaoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="BackEndContext"/>.
        /// </param>
        public SituacaoRepository(BackEndContext context)
            : base(context)
        {
        }
    }
}
