using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using HomeworkDistributionPortal.Dtos;
using HomeworkDistributionPortal.Models;

namespace HomeworkDistributionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class ClassController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ClassController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Class
        [HttpGet]
        public ActionResult<IEnumerable<ClassDto>> GetClasses()
        {
            var classItems = _context.Classes.ToList();
            var classItemDtoList = _mapper.Map<List<ClassDto>>(classItems);
            return classItemDtoList;
        }

        // GET: api/Class/5
        [HttpGet("{id}")]
        public ActionResult<ClassDto> GetClass(int id)
        {
            var classItem = _context.Classes.FirstOrDefault(b => b.Class_id == id);
            if (classItem == null)
            {
                return NotFound();
            }

            var classItemDto = _mapper.Map<ClassDto>(classItem);
            return classItemDto;
        }

        // POST: api/Class
        [HttpPost]
     
        public ActionResult<ResultDto> PostClass(ClassDto classItemDto)
        {
            var classItem = _mapper.Map<Class>(classItemDto);

            _context.Classes.Add(classItem);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Class added." });
        }

        // PUT: api/Class/5
        [HttpPut("{id}")]
       
        public IActionResult PutClass(int id, ClassDto classItemDto)
        {
            var classItem = _context.Classes.FirstOrDefault(b => b.Class_id == id);
            if (classItem == null)
            {
                return NotFound("Class not found.");
            }

            // Bölüm bilgilerini güncelle
            classItem.Class_name = classItemDto.Class_name;

            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Class updated." });
        }

        // DELETE: api/Class/5
        [HttpDelete("{id}")]
       
        public IActionResult DeleteClass(int id)
        {
            var classItem = _context.Classes.FirstOrDefault(b => b.Class_id == id);
            if (classItem == null)
            {
                return NotFound("Class not found.");
            }

            _context.Classes.Remove(classItem);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Class deleted." });
        }
    }
}
