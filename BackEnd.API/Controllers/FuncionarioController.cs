namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public class FuncionarioController : BaseController<FuncionarioViewModel, FuncionarioFilter, Funcionario>
    {
        public FuncionarioController(IFuncionarioAppService funcionarioAppService)
            : base(funcionarioAppService)
        {
        }
    }
}