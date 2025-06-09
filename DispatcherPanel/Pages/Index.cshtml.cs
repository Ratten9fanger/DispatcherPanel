using DispatcherPanel.Data;
using DispatcherPanel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DispatcherPanel.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<EmergencyRequest> ActiveRequests { get; set; } = new();
        public List<EmergencyRequest> ProcessedRequests { get; set; } = new();

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            ActiveRequests = _context.EmergencyRequests.Where(r => !r.IsProcessed).ToList();
            ProcessedRequests = _context.EmergencyRequests.Where(r => r.IsProcessed).ToList();
        }

        public IActionResult OnPostMarkAsProcessed(Guid id)
        {
            var request = _context.EmergencyRequests.Find(id);
            if (request != null)
            {
                request.IsProcessed = true;
                _context.SaveChanges();
            }

            return RedirectToPage("/Index");
        }
    }
}
