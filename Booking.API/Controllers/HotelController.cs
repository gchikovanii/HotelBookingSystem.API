using Booking.API.Constants;
using Booking.Application.Model.HotelAggregate;
using Booking.Application.Services.Abstraction.HotelAggregate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Booking.API.Controllers
{
    public class HotelController : BaseController
    {
        private readonly IHotelService _hotelService; 
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetHotelById(int id)
        {
            var hotel = await _hotelService.GetHotelById(id);
            if (hotel == null)
                return NotFound();
            return Ok(hotel);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelService.GetAllHotels();
            return Ok(hotels);
        }

        [HttpGet(nameof(GetPaiginatedHotels))]
        public async Task<IActionResult> GetPaiginatedHotels(int index, int pageSize)
        {
            var hotels = await _hotelService.GetHotels(index, pageSize);
            return Ok(hotels);
        }


        [HttpPost]
        [Authorize(Roles = UserType.AdminUser)]
        public async Task<IActionResult> CreateHotel(CreateHotelDto input)
        {
            var result = await _hotelService.CreateHotel(input);
            if (result == false)
                return BadRequest();
            return Ok();

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateHotel(int id, UpdateHotelDto input)
        {
            var result = await _hotelService.UpdateHotel(id, input);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            return Ok(await _hotelService.DeleteHotel(id));
        }
    
    }
}
