using Microsoft.AspNetCore.Mvc;

namespace ManagerHairdresser.Api.Controllers.Shared
{

    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ApiControllerBase : ControllerBase { }
}

