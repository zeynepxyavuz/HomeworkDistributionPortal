using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkDistributionPortal.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int HomeworkId { get; set; }

        [ForeignKey("StudentId")]
        public string StudentId { get; set; }

        public Homework Homework { get; set; }

        [ForeignKey("StudentId")]
        public AppUser Student { get; set; }

        public DateTime DeliveryDate { get; set; }
        public DateTime UpdateDate { get; set; }

        public string FilePath { get; set; }
    }
}

