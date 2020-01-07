namespace BackEnd.Infra.Data.Repositories
{
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;

    /// <summary>
    ///     Implementação da <see cref="ICargoRepository"/>.
    /// </summary>
    public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CargoRepository"/> class.
        ///     Construtor padrão de <see cref="CargoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="BackEndContext"/>.
        /// </param>
        public CargoRepository(BackEndContext context)
            : base(context)
        {
        }
    }
}
