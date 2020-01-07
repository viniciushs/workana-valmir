namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public class SituacaoController : BaseController<SituacaoViewModel, SituacaoFilter, Situacao>
    {
        public SituacaoController(ISituacaoAppService situacaoAppService)
            : base(situacaoAppService)
        {
        }
    }
}