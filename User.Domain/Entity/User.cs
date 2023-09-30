using System;
using System.Collections.Generic;

namespace User.Domain.Entity;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;
}
