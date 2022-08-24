using System.ComponentModel.DataAnnotations;

namespace SampleAPIs.Entities
{
    public class Rockstar
    {
        [Key]
        public int RockId { get; set; }
        public string RockName { get; set; }
        public string RockEmail { get; set; }
        public string RockPhoneNumber { get; set; }
        public double BillableHours { get; set; }
    }
}
