
public class PaginationPartialDto
{
    public int Id { get; set; }
    public string ReloadEvents { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
}
