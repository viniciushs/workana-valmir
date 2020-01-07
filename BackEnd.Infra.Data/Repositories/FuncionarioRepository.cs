namespace BackEnd.Infra.Data.Repositories
{
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;

    /// <summary>
    ///     Implementação da <see cref="IFuncionarioRepository"/>.
    /// </summary>
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuncionarioRepository"/> class.
        ///     Construtor padrão de <see cref="FuncionarioRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="BackEndContext"/>.
        /// </param>
        public FuncionarioRepository(BackEndContext context)
            : base(context)
        {
        }
    }
}
