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
    
    public class DeliveryController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public DeliveryController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Delivery
        [HttpGet]
        public ActionResult<IEnumerable<DeliveryDto>> GetDeliveryies()
        {
            var deliveryies = _context.Deliveryies.ToList();
            var deliveryDtoList = _mapper.Map<List<DeliveryDto>>(deliveryies);
            return deliveryDtoList;
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]
        public ActionResult<DeliveryDto> GetDelivery(int id)
        {
            var delivery = _context.Deliveryies.FirstOrDefault(t => t.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound();
            }

            var deliveryDto = _mapper.Map<DeliveryDto>(delivery);
            return deliveryDto;
        }

        // POST: api/Delivery
        [HttpPost]
        public ActionResult<ResultDto> PostDelivery(DeliveryDto deliveryDto)
        {
            var delivery = _mapper.Map<Delivery>(deliveryDto);
            delivery.DeliveryDate = DateTime.Now;
            delivery.UpdateDate = DateTime.Now;

            _context.Deliveryies.Add(delivery);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Delivery was completed successfully." });
        }

        // PUT: api/Delivery/5
        [HttpPut("{id}")]
        public IActionResult PutDelivery(int id, DeliveryDto deliveryDto)
        {
            var delivery = _context.Deliveryies.FirstOrDefault(t => t.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound("Delivery not found.");
            }

            // Delivery bilgilerini güncelle
            delivery.HomeworkId = deliveryDto.HomeworkId;
            delivery.StudentId = deliveryDto.StudentId;
            delivery.FilePath = deliveryDto.FilePath;
            delivery.UpdateDate = DateTime.Now;

            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "Delivery information has been updated." });
        }

        // DELETE: api/Delivery/5
        [HttpDelete("{id}")]
        public IActionResult DeleteDelivery(int id)
        {
            var delivery = _context.Deliveryies.FirstOrDefault(t => t.DeliveryId == id);
            if (delivery == null)
            {
                return NotFound("Delivery not found.");
            }

            _context.Deliveryies.Remove(delivery);
            _context.SaveChanges();

            return Ok(new ResultDto { Status = true, Message = "The delivery was deleted successfully." });
        }
    }
}
