namespace BackEnd.Infra.Data.Repositories
{
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Data.Contexts;
    using BackEnd.Infra.Data.Interfaces;

    /// <summary>
    ///     Implementação da <see cref="IFormaPagamentoRepository"/>.
    /// </summary>
    public class FormaPagamentoRepository : BaseRepository<FormaPagto>, IFormaPagamentoRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormaPagamentoRepository"/> class.
        ///     Construtor padrão de <see cref="FormaPagamentoRepository"/>.
        /// </summary>
        /// <param name="context">
        ///     O contexto do repositório. Veja <see cref="BackEndContext"/>.
        /// </param>
        public FormaPagamentoRepository(BackEndContext context)
            : base(context)
        {
        }
    }
}
