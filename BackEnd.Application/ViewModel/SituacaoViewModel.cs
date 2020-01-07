using System.ComponentModel.DataAnnotations;

namespace BackEnd.Application.ViewModel
{
    public class SituacaoViewModel : BaseViewModel
    {
        [Key]
        public int IdSituacao { get; set; }

        public string DescricaoSituacao { get; set; }
    }
}
