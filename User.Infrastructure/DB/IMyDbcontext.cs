using Microsoft.EntityFrameworkCore;
using User.Domain.Entity;

namespace User.Infrastructure.DB;

public interface IMyDbcontext
{
    DbSet<Favorite> Favorites { get; set; }
    DbSet<Image> Images { get; set; }
    DbSet<Phone> Phones { get; set; }
    DbSet<Post> Posts { get; set; }
    DbSet<Domain.Entity.User> Users { get; set; }
    DbSet<User1> Users1 { get; set; }
}