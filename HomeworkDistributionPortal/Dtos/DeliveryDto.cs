using HomeworkDistributionPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkDistributionPortal.Dtos
{
    public class DeliveryDto
    {
        public int DeliveryId { get; set; }
        public int HomeworkId { get; set; }


        public string StudentId { get; set; }
        

        public DateTime Deadline { get; set; }
        public DateTime UpdateDate { get; set; }

        public string FilePath { get; set; }
    }

}
