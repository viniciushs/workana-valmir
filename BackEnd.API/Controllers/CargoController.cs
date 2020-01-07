namespace BackEnd.API.Controllers
{
    using BackEnd.Application.Filters;
    using BackEnd.Application.Interfaces;
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;

    public class CargoController : BaseController<CargoViewModel, CargoFilter, Cargo>
    {
        public CargoController(ICargoAppService cargoAppService)
            : base(cargoAppService)
        {
        }
    }
}