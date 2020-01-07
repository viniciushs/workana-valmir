namespace BackEnd.Application.Interfaces
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public interface IFuncionarioAppService : IBaseAppService<FuncionarioViewModel, FuncionarioFilter, Funcionario>
    {
    }
}
