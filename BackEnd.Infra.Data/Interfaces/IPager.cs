namespace BackEnd.Infra.Data.Interfaces
{
    public interface IPager
    {
        int PageNumber { get; set; }
        int PageSize { get; set; }
        bool HasPagination { get; set; }
    }
}
