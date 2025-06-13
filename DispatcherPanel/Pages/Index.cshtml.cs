using DispatcherPanel.Data;
using DispatcherPanel.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DispatcherPanel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public List<EmergencyRequest> ActiveRequests { get; set; } = new();
        public List<EmergencyRequest> ProcessedRequests { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            ActiveRequests = context.EmergencyRequests.Where(r => !r.IsProcessed).ToList();
            ProcessedRequests = context.EmergencyRequests.Where(r => r.IsProcessed).ToList();
        }

        public IActionResult OnPostMarkAsProcessed([FromBody] Guid id)
        {
            var request = context.EmergencyRequests.Find(id);
            if (request != null)
            {
                request.IsProcessed = true;
                context.SaveChanges();
            }

            return new JsonResult(new { success = true });
        }

        public IActionResult OnGetGetProcessedRequests()
        {
            var requests = context.EmergencyRequests
                .Where(r => r.IsProcessed)
                .Select(r => new
                {
                    r.Id,
                    r.FullName,
                    r.Category,
                    r.Description
                }).ToList();

            return new JsonResult(new { requests });
        }
    }
}
