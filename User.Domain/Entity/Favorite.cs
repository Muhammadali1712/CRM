using System;
using System.Collections.Generic;

namespace User.Domain.Entity;

public partial class Favorite
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PhoneId { get; set; }

    public virtual Phone Phone { get; set; } = null!;

    public virtual User1 User { get; set; } = null!;
}
