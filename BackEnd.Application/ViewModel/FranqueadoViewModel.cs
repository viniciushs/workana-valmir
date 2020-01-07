using BackEnd.Application.Filters;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackEnd.Application.ViewModel
{
    public class FranqueadoViewModel : BaseViewModel
    {
        public FranqueadoViewModel()
        {
            this.Filter = new FranqueadoFilter();
        }

        [Key]
        public int IdFranqueado { get; set; }
        public string DescricaoFranqueado { get; set; }
        public string NomeFantasia { get; set; }
        public int IdSituacao { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime? DataCancelamento { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public System.DateTime DataCadastro { get; set; }

        public virtual SituacaoViewModel Situacao { get; set; }

        public virtual ICollection<FuncionarioViewModel> Funcionario { get; set; }

        public virtual FranqueadoFilter Filter { get; set; }
    }
}
