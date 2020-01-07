using System;

namespace BackEnd.Application.Filters
{
    public class FranqueadoFilter : BaseFilter
    {
        public int? IdFranqueado { get; set; }
        
        public string DescricaoFranqueado { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string Cpf { get; set; }
        public DateTime? DataCancelamento { get; set; }
        public DateTime? DataCadastro { get; set; }
        public int? IdSituacao { get; set; }
        public string DescricaoSituacao { get; set; }
        public int? IdFuncionario { get; set; }
        public string DescricaoFuncionario { get; set; }
    }
}
