namespace BackEnd.Infra.Data.Repositories
{
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;

    /// <summary>
    ///     Implementação da <see cref="IFranqueadoRepository"/>.
    /// </summary>
    public class FranqueadoRepository : BaseRepository<Franqueado>, IFranqueadoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FranqueadoRepository"/> class.
        ///     Construtor padrão de <see cref="FranqueadoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="BackEndContext"/>.
        /// </param>
        public FranqueadoRepository(BackEndContext context)
            : base(context)
        {
        }
    }
}
