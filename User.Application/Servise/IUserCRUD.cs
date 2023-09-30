namespace User.Application.Servise;

public interface IUserCRUD<T>
{
    public T Create(T user);
    public bool Update(T user);
    public bool Delete(int id);
    public T GetById(string id);
    public IEnumerable<T> GetAll();
}
