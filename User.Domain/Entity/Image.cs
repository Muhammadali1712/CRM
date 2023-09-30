using System;
using System.Collections.Generic;

namespace User.Domain.Entity;

public partial class Image
{
    public int Id { get; set; }

    public byte[] Image1 { get; set; } = null!;

    public string Description { get; set; } = null!;
}
