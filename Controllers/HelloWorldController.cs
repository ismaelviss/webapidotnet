using Microsoft.AspNetCore.Mvc;
using webapi;
using webapidotnet.Services;

namespace webapidotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;

        TareasContext dbContext;

        public HelloWorldController(IHelloWorldService helloWorld, TareasContext dbContext) 
        {
            helloWorldService = helloWorld;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("CreateDatabase")]
        public IActionResult CreateDatabase()
        {
            dbContext.Database.EnsureCreated();

            return Ok();
        }
        
    }
}