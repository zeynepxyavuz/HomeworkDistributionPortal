using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkDistributionPortal.Models
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? StudentNumber { get; set; }

        [ForeignKey("Classes")]
        public int ClassId { get; set; }

        public List<Delivery> Deliveryies { get; set; }
        public List<Homework> Homeworks { get; set; }
    }
}
