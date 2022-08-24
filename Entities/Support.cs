using System.ComponentModel.DataAnnotations;

namespace SampleAPIs.Entities
{
    public class Support
    {
        [Key]
        public int TicketId { get; set; }
        public string Issues { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ClosedDate { get; set; }
        public int AssignedTo { get; set; }
    }
}
