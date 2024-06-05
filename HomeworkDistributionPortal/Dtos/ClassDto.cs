using HomeworkDistributionPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace HomeworkDistributionPortal.Dtos
{
    public class ClassDto
    {
        [Key]
        public int Class_id { get; set; }

        public string Class_name { get; set; }

    }
}
