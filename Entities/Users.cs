using System.ComponentModel.DataAnnotations;

namespace SampleAPIs.Entities
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PhoneNumber { get; set; }
    }
}
