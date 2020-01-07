using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;

namespace BackEnd.Domain.Models
{
    public partial class FormaPagto : BaseEntity
    {
        public int IdFormaPagto { get; set; }
        public string DescricaoFormaPagto { get; set; }
    }
}
