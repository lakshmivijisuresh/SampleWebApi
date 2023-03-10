using System;
using System.Collections.Generic;

namespace SampleWebApi.Models;

public partial class Clientss
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime CreatedAt { get; set; }
}
