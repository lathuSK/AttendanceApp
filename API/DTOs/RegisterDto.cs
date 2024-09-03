using System;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class RegisterDto
    {
        [Required]
        public string Username { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Department { get; set; } = string.Empty;
        [Required]
        public string JobId { get; set; } = string.Empty;
    }
