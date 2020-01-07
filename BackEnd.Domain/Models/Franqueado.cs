using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;

namespace BackEnd.Domain.Models
{
    public partial class Franqueado : BaseEntity
    {
        public Franqueado()
        {
            Funcionario = new HashSet<Funcionario>();
        }

        public int IdFranqueado { get; set; }
        public int IdSituacao { get; set; }
        public string DescricaoFranqueado { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime DataCadastro { get; set; }

        public Situacao IdSituacaoNavigation { get; set; }
        public ICollection<Funcionario> Funcionario { get; set; }
    }
}
