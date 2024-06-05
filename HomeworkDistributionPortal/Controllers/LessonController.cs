using HomeworkDistributionPortal.Models;
using HomeworkDistributionPortal.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace HomeworkDistributionPortal.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LessonController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Tüm dersleri getiren endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LessonDto>>> GetLessons()
        {
            var lessons = await _context.Lessons.ToListAsync();
            var lessonDtoList = _mapper.Map<List<LessonDto>>(lessons);
            return lessonDtoList;
        }

        // Belirli bir dersin bilgilerini getiren endpoint
        [HttpGet("{id}")]
        public async Task<ActionResult<LessonDto>> GetLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);

            if (lesson == null)
            {
                return NotFound();
            }

            var lessonDto = _mapper.Map<LessonDto>(lesson);
            return lessonDto;
        }

        // Yeni ders ekleme endpoint
        [Authorize(Roles = "Admin,Ogretmen")]
        [HttpPost]
        public async Task<ActionResult<ResultDto>> PostLesson(LessonDto lessonDto)
        {
            var lesson = _mapper.Map<Lesson>(lessonDto);

            _context.Lessons.Add(lesson);
            await _context.SaveChangesAsync();

            var result = new ResultDto { Status = true, Message = "Course added successfully" };
            return result;
        }

        // Belirli bir dersi güncelleme endpoint
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLesson(int id, LessonDto lessonDto)
        {
            if (id != lessonDto.Lesson_id)
            {
                return BadRequest();
            }

            var lesson = _mapper.Map<Lesson>(lessonDto);

            _context.Entry(lesson).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LessonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Belirli bir dersi silme endpoint
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson(int id)
        {
            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }

            _context.Lessons.Remove(lesson);
            await _context.SaveChangesAsync();

            return Ok(new ResultDto { Status = true, Message = "The course has been deleted successfully." });
        }

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.Lesson_id == id);
        }
    }
}
