namespace BackEnd.Infra.Data.Interfaces
{
    using BackEnd.Domain.Models;

    /// <summary>
    ///     Interface de contrato de repositório para <see cref="Funcionario"/>.
    /// </summary>
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
    }
}
