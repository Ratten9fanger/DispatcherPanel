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

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsProcessed { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
