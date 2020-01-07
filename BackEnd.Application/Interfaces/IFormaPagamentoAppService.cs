namespace BackEnd.Application.Interfaces
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public interface IFormaPagamentoAppService : IBaseAppService<FormaPagamentoViewModel, FormaPagamentoFilter, FormaPagto>
    {
    }
}
