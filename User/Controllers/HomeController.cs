using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using User.Application.Servise;

namespace User.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : Controller
{
    private readonly IUserCRUD<User.Domain.Entity.User> _iuser;
    private readonly ILogger<HomeController> _logger;


    public HomeController(IUserCRUD<Domain.Entity.User> iuser, ILogger<HomeController> logger)
    {
        _iuser = iuser;
        _logger = logger;
    }

    [HttpPost]
    [Route("[action]")]
    public Domain.Entity.User Create(Domain.Entity.User user)
    {
        Domain.Entity.User created = _iuser.Create(user);
        
        return created;
    }
    [HttpPut]
    [Route("[action]")]
    public bool Update(Domain.Entity.User user)
    {
        bool Updated = _iuser.Update(user);
        return Updated == true ? true : false;
    }
    [HttpDelete]
    [Route("[action]")]
    public bool Delete(int id)
    {
        bool deleted = _iuser.Delete(id);
        return deleted == true ? true : false;
    }
    [HttpGet]
    [Route("[action]")]
    public Domain.Entity.User GetById(string id)
    {
        Domain.Entity.User get = _iuser.GetById(id);
        return get;
    }
    [HttpGet]
    [Route("[action]")]
    public IEnumerable<Domain.Entity.User> GetAll()
    {
        IEnumerable<Domain.Entity.User> getall = _iuser.GetAll();
        return getall;
    }
}
