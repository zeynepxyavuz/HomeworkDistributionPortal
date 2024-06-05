using HomeworkDistributionPortal.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeworkDistributionPortal.Dtos
{
    public class LessonDto
    
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public int Lesson_id { get; set; }

            public string LessonName { get; set; }

           
            public int Class_id { get; set; }

           
        }
    }

