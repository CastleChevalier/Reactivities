using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //whatever the base name of the controller is, minus the controller
    public class BaseApiController : ControllerBase
    {
        
    }
}