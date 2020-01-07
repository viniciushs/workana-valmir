namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Utils.Messages;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Net;

    public class FranqueadoController : BaseController<FranqueadoViewModel, FranqueadoFilter, Franqueado>
    {
        public FranqueadoController(IFranqueadoAppService franqueadoAppService)
            : base(franqueadoAppService)
        {
        }

        [HttpGet]
        public override IActionResult Get([FromQuery]FranqueadoFilter filter)
        {
            try
            {
                var result = this.appService.GetBy(filter, f => f.Funcionario);
                return this.Response(result);
            }
            catch (BackEndException bex)
            {
                this.Notifications.Add(bex.Message);
                return this.Response(bex, HttpStatusCode.OK, bex.Message);
            }
            catch (Exception ex)
            {
                this.Notifications.Add(Messages.InternalServerError);
                return this.Response(ex, HttpStatusCode.InternalServerError, Messages.InternalServerError);
            }
        }
    }
}