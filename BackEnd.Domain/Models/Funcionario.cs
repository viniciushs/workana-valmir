using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;

namespace BackEnd.Domain.Models
{
    public partial class Funcionario : BaseEntity
    {
        public int IdFuncionario { get; set; }
        public int IdFranqueado { get; set; }
        public int IdSituacao { get; set; }
        public DateTime DataCadastro { get; set; }
        public string DescricaoFuncionario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public Franqueado IdFranqueadoNavigation { get; set; }
        public Situacao IdSituacaoNavigation { get; set; }
    }
}
