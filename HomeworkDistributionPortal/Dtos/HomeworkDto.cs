using HomeworkDistributionPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeworkDistributionPortal.Dtos
{
        public class HomeworkDto
        {
            public int HomeworkId { get; set; }
            public string Title { get; set; }
            public string Explanation { get; set; }
            public int Lesson_id { get; set; }

            public DateTime CreationDate { get; set; }

            public DateTime UpdateDate { get; set; }

            public DateTime Deadline { get; set; }


           
            public string UserId { get; set; }
        
          
        }
    }

