namespace BackEnd.Application.Filters
{
    using BackEnd.Infra.Data.Interfaces;

    public class BaseFilter : IFilter
    {
        /// <summary>
        /// Numero da página. Valor minimo 1.
        /// </summary>
        public int? PageNumber { get; set; }

        /// <summary>
        /// Tamanho da pagina. Valor padrão 25.
        /// </summary>
        public int? PageSize { get; set; }

        /// <summary>
        /// Indicador se deve ser paginado.
        /// </summary>
        public bool HasPagination { get; set; }

        private string _sortBy;

        /// <summary>
        /// Campo pelo qual deve ser feito a ordenação. Valor padrão Id.
        /// </summary>
        public string SortBy
        {
            get
            {
                return this._sortBy ?? "id";
            }
            set
            {
                this._sortBy = value;
            }
        }

        /// <summary>
        /// Direção da ordenaçao. Pode assumir dois valores: ASC ou DESC.
        /// </summary>
        /// <value>
        ///     Pode assumir dois valores:
        ///         1. ASC
        ///             Representa ordem crescente
        ///         2. DESC
        ///             Representa ordem decrescente
        /// </value>
        public string SortDirection { get; set; }

        /// <summary>
        /// Procura por todos os campos da tabela
        /// </summary>
        public string Search { get; set; }
    }
}
