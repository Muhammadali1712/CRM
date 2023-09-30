using User.Application.Servise;
using User.Infrastructure.DB;

namespace User.Infrastructure.Servise;

public class UserCRUD : IUserCRUD<Domain.Entity.User>
{
    private MyDbcontext _dbcontext;
    public UserCRUD(MyDbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public Domain.Entity.User Create(Domain.Entity.User user)
    {
        if (user.Name != null && user.Email != null)
        {
            _dbcontext.Users.Add(user);
            _dbcontext.SaveChanges();
            return user;
        }
        else
        {
            return null;
        }
    }

    public bool Delete(int id)
    {
        var s = _dbcontext.Users.First(x => x.Id == id);
        if (s != null)
        {
            _dbcontext.Users.Remove(s);
            _dbcontext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerable<Domain.Entity.User> GetAll()
    {
        return _dbcontext.Users.ToList();
    }

    public Domain.Entity.User GetById(string id)
    {
        var GetCar = _dbcontext.Users.FirstOrDefault(x => x.Id == Convert.ToInt32(id));
        if (GetCar != null)
        {
            return GetCar;
        }
        else
        {
            return null;
        }
    }

    public bool Update(Domain.Entity.User user)
    {
        var Updatecar = _dbcontext.Users.FirstOrDefault(x => x.Id == user.Id);
        if (Updatecar != null)
        {
            Updatecar.Name = user.Name;
            Updatecar.Email = user.Email;
            _dbcontext.Users.Update(Updatecar);
            _dbcontext.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }
}
