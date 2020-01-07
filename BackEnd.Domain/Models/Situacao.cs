using System.Collections.Generic;

namespace BackEnd.Domain.Models
{
    public partial class Situacao : BaseEntity
    {
        public Situacao()
        {
            Franqueado = new HashSet<Franqueado>();
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdSituacao { get; set; }
        public string DescricaoSituacao { get; set; }

        public ICollection<Franqueado> Franqueado { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
