using System;
using System.Collections.Generic;

namespace User.Domain.Entity;

public partial class User1
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? TelegramUsername { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual ICollection<Post> Posts { get; set; } = new List<Post>();
}
