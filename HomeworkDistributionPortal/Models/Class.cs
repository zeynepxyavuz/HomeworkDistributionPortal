using System.ComponentModel.DataAnnotations;

namespace HomeworkDistributionPortal.Models
{
    public class Class
    {
        [Key]
        public int Class_id { get; set; }

        public string Class_name{ get; set; }

        public List<Lesson> Lessons { get; set; }

        public List<AppUser> AppUsers { get; set; }
    }
}
