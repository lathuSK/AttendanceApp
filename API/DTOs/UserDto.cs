using System;

namespace API.DTOs;

public class UserDto
{
    public required string Token { get; set; }
    public required string Username { get; set; }
    public required string Name { get; set; }
    public required string Department { get; set; }
    public required string JobId { get; set; }
}
