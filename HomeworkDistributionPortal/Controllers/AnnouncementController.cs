using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using HomeworkDistributionPortal.Dtos;
using HomeworkDistributionPortal.Models;

namespace HomeworkDistributionPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AnnouncementController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AnnouncementController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Announcement
        [HttpGet]
        public ActionResult<IEnumerable<AnnouncementDto>> GetAnnouncementlar()
        {
            var announcements = _context.Announcements.ToList();
            var announcementDtoList = _mapper.Map<List<AnnouncementDto>>(announcements);
            return announcementDtoList;
        }

        // GET: api/Announcement/5
        [HttpGet("{id}")]
        public ActionResult<AnnouncementDto> GetAnnouncement(int id)
        {
            var announcement = _context.Announcements.FirstOrDefault(d => d.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound();
            }

            var announcementDto = _mapper.Map<AnnouncementDto>(announcement);
            return announcementDto;
        }

        // POST: api/Announcement
        [HttpPost]
        
        public ActionResult<ResultDto> PostAnnouncement(AnnouncementDto announcementDto)
        {
            var announcement = _mapper.Map<Announcement>(announcementDto);
            announcement.ReleaseDate = DateTime.Now;

            _context.Announcements.Add(announcement);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "\r\nAnnouncement published successfully." });
        }

        // PUT: api/Announcement/5
        [HttpPut("{id}")]
       
        public IActionResult PutAnnouncement(int id, AnnouncementDto announcementDto)
        {
            var announcement = _context.Announcements.FirstOrDefault(d => d.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound("Announcement not found.");
            }

            // Duyuru bilgilerini güncelle
            announcement.Text = announcementDto.Text;

            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Announcement updated." });
        }

        // DELETE: api/Announcement/5
        [HttpDelete("{id}")]
        
        public IActionResult DeleteAnnouncement(int id)
        {
            var announcement = _context.Announcements.FirstOrDefault(d => d.AnnouncementId == id);
            if (announcement == null)
            {
                return NotFound("Announcement not found.");
            }

            _context.Announcements.Remove(announcement);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Announcement deleted." });
        }
    }
}
