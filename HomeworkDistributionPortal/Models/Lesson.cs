using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeworkDistributionPortal.Models
{
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lesson_id { get; set; }

        public string LessonName { get; set; }

        [ForeignKey("Classes")]
        public int Class_id { get; set; }
        public Class Classes { get; set; }
        public List<Homework> Homeworks { get; set; }
    }
}
