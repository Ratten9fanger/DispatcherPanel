using DispatcherPanel.Data;
using DispatcherPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace DispatcherPanel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext context;

        public RequestController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EmergencyRequest request)
        {
            Console.WriteLine(request.FullName);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            request.Id = Guid.NewGuid();
            request.CreatedAt = DateTime.Now;
            await context.EmergencyRequests.AddAsync(request);
            await context.SaveChangesAsync();

            return Ok(new { success = true });
        }
    }
}
