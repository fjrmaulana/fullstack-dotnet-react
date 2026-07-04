using BackEnd_App.Data;
using BackEnd_App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEnd_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly AppDbContext context;
        public ActivitiesController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async System.Threading.Tasks.Task<ActionResult<List<BackEnd_App.Models.Activity>>> GetActivity(){
           return await context.Activities.ToListAsync();
        }
    }
}
