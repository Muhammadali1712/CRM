using System;
using System.Collections.Generic;

namespace User.Domain.Entity;

public partial class Phone
{
    public int Id { get; set; }

    public string? Brand { get; set; }

    public string? Model { get; set; }

    public decimal Price { get; set; }

    public short Color { get; set; }

    public short Condition { get; set; }

    public byte[]? Image { get; set; }

    public int? PostId { get; set; }

    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();

    public virtual Post? Post { get; set; }
}
