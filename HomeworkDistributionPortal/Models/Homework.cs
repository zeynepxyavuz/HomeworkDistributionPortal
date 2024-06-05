using HomeworkDistributionPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace HomeworkDistributionPortal.Models


{

    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Title { get; set; }
        public string Explanation { get; set; }
        
    [ForeignKey("Lessons")]
        public int Lesson_id { get; set; }
        public DateTime CreationDate { get; set; }

        public DateTime UpdateDate { get; set; }

        public DateTime Deadline { get; set; }


        [ForeignKey("AppUsers")]
        public string User_id { get; set; }
        public Lesson Lessons  { get; set; }
        public AppUser AppUsers { get; set; }
        public List<Delivery> Deliveryies { get; set; }
    }
}

