using HomeworkDistributionPortal.Models;
using HomeworkDistributionPortal.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace HomeworkDistributionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeworkController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Tüm ödevleri getiren endpoint
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomeworkDto>>> GetHomeworks()
        {
            var homeworks = await _context.Homeworks.ToListAsync();
            var homeworkDtoList = _mapper.Map<List<HomeworkDto>>(homeworks);
            return homeworkDtoList;
        }

        // Belirli bir ödevin bilgilerini getiren endpoint
        [HttpGet("{id}")]
        public async Task<ActionResult<HomeworkDto>> Gethomework(int id)
        {
            var homework = await _context.Homeworks.FindAsync(id);

            if (homework == null)
            {
                return NotFound();
            }

            var homeworkDto = _mapper.Map<HomeworkDto>(homework);
            return homeworkDto;
        }

        // Yeni ödev ekleme endpoint
        [HttpPost]
        public async Task<ActionResult<ResultDto>> PostHomework(HomeworkDto homeworkDto)
        {
            var homework = _mapper.Map<Homework>(homeworkDto);

            _context.Homeworks.Add(homework);
            await _context.SaveChangesAsync();

            var result = new ResultDto { Status = true, Message = "Homeworks added." };
            return result;
        }

        // Belirli bir ödevi güncelleme endpoint
        [HttpPut("{id}")]
        public async Task<ResultDto> PutHomework(int id, HomeworkDto homeworkDto)
        {
            var result = new ResultDto();
            if (id != homeworkDto.HomeworkId)
            {
                result.Status = false;
                result.Message = "Odev bulunamadı.";
                return result;
            }

            var homework = _mapper.Map<Homework>(homeworkDto);

            _context.Entry(homework).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                result.Status = true;
                result.Message = "Updated.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeworkExists(id))
                {
                    result.Message = "Homework not found.";
                    result.Status = false;
                    return result;
                }
                else
                {
                    throw;
                }
            }

            return result;
        }

        // Belirli bir ödevi silme endpoint
        [HttpDelete("{id}")]
        public async Task<ResultDto> DeleteHomework(int id)
        {
            var result = new ResultDto();

            var homework = await _context.Homeworks.FindAsync(id);
            if (homework == null)
            {
                result.Message = "Homework not found.";
                result.Status = false;
                return result;
            }

            _context.Homeworks.Remove(homework);
            await _context.SaveChangesAsync();
            result.Message = "Homework deleted.";
            result.Status = true;
            return result;
        }

        private bool HomeworkExists(int id)
        {
            return _context.Homeworks.Any(e => e.HomeworkId == id);
        }
    }
}
