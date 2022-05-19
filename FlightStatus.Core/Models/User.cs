namespace FlightStatus.Core.Models;

public class User
{
    public long ID { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}