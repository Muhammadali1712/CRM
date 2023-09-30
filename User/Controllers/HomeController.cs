using Microsoft.AspNetCore.Mvc;
using User.Application.Servise;
using User.Domain.Models.UserDTO;

namespace User.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : Controller
{
    private readonly IUserCRUD<Domain.Entity.User> _iuser;


    public HomeController(IUserCRUD<Domain.Entity.User> iuser)
    {
        _iuser = iuser;
    }

    [HttpPost]
    [Route("[action]")]
    public GetUserDto Create(CreateUserDto createUserDto)
    {
        Domain.Entity.User user = new Domain.Entity.User()
        {
            Name = createUserDto.Name,
            Email = createUserDto.Email,
        };

        Domain.Entity.User created = _iuser.Create(user);

        GetUserDto getUserDto = new GetUserDto()
        {
            Id = created.Id,
            Name = created.Name,
        };

        return getUserDto;
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
    public GetUserDto GetById(string id)
    {
        var g = _iuser.GetById(id);
        GetUserDto get = new GetUserDto()
        {
            Id = g.Id,
            Name = g.Name,
        };
        return get;
    }
    [HttpGet]
    [Route("[action]")]
    public IEnumerable<GetUserDto> GetAll()
    {
        var getall = from u in _iuser.GetAll()
                     select new GetUserDto
                     {
                         Id = u.Id,
                         Name = u.Name,
                     };
        return getall;
    }
}
