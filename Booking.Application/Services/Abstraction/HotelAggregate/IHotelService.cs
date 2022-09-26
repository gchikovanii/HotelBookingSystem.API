using Booking.Application.Model.HotelAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Abstraction.HotelAggregate
{
    public interface IHotelService
    {
        Task<List<GetHotelDto>> GetHotelById(int id);
        Task<List<GetHotelDto>> GetHotels(int page, int pageSize);
        Task<List<GetHotelDto>> GetAllHotels();
        Task<bool> CreateHotel(CreateHotelDto input);
        Task<bool> UpdateHotel(int HotelId, UpdateHotelDto input);
        Task<bool> DeleteHotel(int hotelId);
    }
}
