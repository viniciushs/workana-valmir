using System.ComponentModel.DataAnnotations;

namespace BackEnd.Application.ViewModel
{
    public class FuncionarioViewModel : BaseViewModel
    {
        [Key]
        public int IdFuncionario { get; set; }
        public int IdFranqueado { get; set; }
        public int IdSituacao { get; set; }

        public string DescricaoFuncionario { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DataCadastro { get; set; }

        public string Senha { get; set; }

        public string Email { get; set; }

        public virtual SituacaoViewModel Situacao { get; set; }
        public virtual FranqueadoViewModel Franqueado { get; set; }

    }
}
