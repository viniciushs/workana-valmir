using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackEnd.Application.ViewModel
{
    public class FormaPagamentoViewModel : BaseViewModel
    {
        public int IdFormaPagto { get; set; }
        public string DescricaoFormaPagto { get; set; }
    }
}
