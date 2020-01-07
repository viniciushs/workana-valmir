namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public class FormaPagamentoController : BaseController<FormaPagamentoViewModel, FormaPagamentoFilter, FormaPagto>
    {
        public FormaPagamentoController(IFormaPagamentoAppService formaPagamentoAppService)
            : base(formaPagamentoAppService)
        {
        }
    }
}