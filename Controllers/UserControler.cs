using Microsoft.AspNetCore.Mvc;
using order_manager.Models;

namespace order_manager.Controllers;

[ApiController]
[Route("api/user")]
public class UserControler : ControllerBase
{
    [HttpPost]
    public User Create([FromBody] User user)
    {
        User createdUser = new User();
        return createdUser;
    }   
}
