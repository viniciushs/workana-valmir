namespace BackEnd.Application.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class CargoViewModel : BaseViewModel
    {
        public int IdCargo { get; set; }
        public string DescricaoCargo { get; set; }
    }
}
