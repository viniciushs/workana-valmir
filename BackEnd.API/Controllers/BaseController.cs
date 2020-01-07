namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using BackEnd.Infra.Utils.Messages;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TViewModel, TFilter, TEntity> : ControllerBase
        where TViewModel : BaseViewModel
        where TFilter : BaseFilter
        where TEntity : BaseEntity
    {
        protected readonly ICollection<string> Notifications;
        protected readonly IBaseAppService<TViewModel, TFilter, TEntity> appService;

        public BaseController(IBaseAppService<TViewModel, TFilter, TEntity> appService)
        {
            Notifications = new List<string>();
            this.appService = appService;
        }

        protected new IActionResult Response(
            object data = null,
            HttpStatusCode statusCode = HttpStatusCode.OK,
            string message = "")
        {
            var response = new ResponseViewModel();

            if (data is ResponseViewModel)
            {
                response = (ResponseViewModel)data;
            }
            else
            {
                response = new ResponseViewModel()
                {
                    Success = !this.Notifications.Any(),
                    Data = !this.Notifications.Any() ? data : null,
                    Notifications = this.Notifications
                };

                if (response.Success)
                {
                    response.Message = string.IsNullOrEmpty(message) ? Messages.RequestSuccess : message;
                }
                else
                {
                    response.Message = string.IsNullOrEmpty(message) ? Messages.RequestError : message;
                }
            }

            return new ObjectResult(response)
            { StatusCode = (int)statusCode };
        }

        /// <summary>
        ///     Obtém o registro cujo ID (Primary Key) é o passado como parâmetro.
        /// </summary>
        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            try
            {
                var item = this.appService.GetById(id);
                return this.Response(item);
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

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet]
        public virtual IActionResult Get([FromQuery]TFilter filter)
        {
            try
            {
                var result = this.appService.GetBy(filter);
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

        /// <summary>
        ///     Obtém todos os registros.
        /// </summary>
        [HttpGet("all")]
        public virtual IActionResult Get()
        {
            try
            {
                var results = this.appService.GetAll();
                return this.Response(results);
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

        /// <summary>
        ///     Adiciona um novo registro.
        /// </summary>
        [HttpPost]
        public virtual IActionResult Post([FromBody] TViewModel obj)
        {
            try
            {
                var _added = this.appService.Add(obj);
                return this.Response(_added, HttpStatusCode.Created, Messages.SaveSuccess);
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

        /// <summary>
        ///     Atualiza um registro existente.
        /// </summary>
        [HttpPut("{id}")]
        public virtual IActionResult Put([FromBody] TViewModel obj)
        {
            try
            {
                this.appService.Update(obj);
                return this.Response(obj, HttpStatusCode.OK, Messages.UpdateSuccess);
            }
            catch (BackEndException bex)
            {
                this.Notifications.Add(bex.Message);
                return this.Response(bex, HttpStatusCode.NoContent, bex.Message);
            }
            catch (Exception ex)
            {
                this.Notifications.Add(Messages.InternalServerError);
                return this.Response(ex, HttpStatusCode.InternalServerError, Messages.InternalServerError);
            }
        }

        /// <summary>
        ///     Deleta um registro existente.
        /// </summary>
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int id)
        {
            try
            {
                this.appService.Remove(id);
                return this.Response(id, HttpStatusCode.OK, Messages.DeleteSuccess);
            }
            catch (BackEndException bex)
            {
                this.Notifications.Add(bex.Message);
                return this.Response(bex, HttpStatusCode.NoContent, bex.Message);
            }
            catch (Exception ex)
            {
                this.Notifications.Add(Messages.InternalServerError);
                return this.Response(ex, HttpStatusCode.InternalServerError, Messages.InternalServerError);
            }
        }
    }
}