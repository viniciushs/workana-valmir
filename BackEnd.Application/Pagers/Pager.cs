namespace BackEnd.Application.Pagers
{
    using BackEnd.Application.Filters;
    using BackEnd.Infra.Data.Interfaces;

    public class Pager : IPager
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public bool HasPagination { get; set; }

        public Pager()
        {
        }

        public Pager(BaseFilter filter)
        {
            this.PageNumber = filter.PageNumber ?? 0;
            this.PageSize = filter.PageSize ?? 25;
            this.HasPagination = filter.HasPagination;
        }
    }
}
