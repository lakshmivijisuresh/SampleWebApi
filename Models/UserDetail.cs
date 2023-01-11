using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SampleWebApi.Models;

public partial class UserDetail
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public string Password { get; set; } = null!;

    public long MobileNumber { get; set; }

    [Key]
    public int UserId { get; set; }

    public string? SecurityAnswer { get; set; }

    public string? SecurityQuestion { get; set; }

    public int? IsAdmin { get; set; }
}
