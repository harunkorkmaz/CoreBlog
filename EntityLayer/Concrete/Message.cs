namespace EntityLayer.Concrete;

public class Message
{
    public int Id { get; set; }
    public int? SenderId { get; set; }
    public int? RecieverId { get; set; }
    public string Subject { get; set; }
    public string MessageDetails { get; set; }
    public DateTime Date { get; set; } = DateTime.UtcNow;
    public bool Status { get; set; }
    public int? UserId { get; set; }
    public AppUser? User { get; set; }
    public ICollection<AppUser> ReceiverUsers { get; set; }
}
