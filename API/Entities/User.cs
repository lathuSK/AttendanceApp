using System;

namespace API.Entities;

public class User
{
    public int Id { get; set; } 
    public required string Username { get; set; } 
    public required string Name { get; set; }
    public required string Department { get; set; }
    public required string JobId { get; set; }
    public required byte[] PasswordHash { get; set; }  
    public required byte[] PasswordSalt { get; set; }

}
