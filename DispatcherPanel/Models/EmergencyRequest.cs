using System.ComponentModel.DataAnnotations;

namespace DispatcherPanel.Models
{
    public class EmergencyRequest
    {
        public Guid Id { get; set; }

        public string Category { get; set; }

        public int Level { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsProcessed { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
