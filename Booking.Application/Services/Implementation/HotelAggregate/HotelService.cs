using Booking.Application.Model.HotelAggregate;
using Booking.Application.Services.Abstraction.HotelAggregate;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Application.Services.Implementation.HotelAggregate
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<List<GetHotelDto>> GetHotelById(int id)
        {
            var hotel = _hotelRepository.GetQuery(i => i.Id == id);
            return await hotel.Select(i => new GetHotelDto
            {
                Id = i.Id,
                Name = i.Name,
                Address = i.Address,
                Latitude = i.Latitude,
                Longtitude = i.Longtitude,
                MaxPrice = i.MaxPrice,
                MinPrice = i.MinPrice
            }).ToListAsync();   
        }
                                                           
        public async Task<List<GetHotelDto>> GetHotels(int page, int pageSize)
        {
            var hotels =  _hotelRepository.GetQuery().Skip((page -1)  * pageSize).Take(pageSize);
            return await hotels.Select(i => new GetHotelDto
            {
                Id = i.Id,
                Name = i.Name,
                Address = i.Address,
                Latitude = i.Latitude,
                Longtitude = i.Longtitude,
                MaxPrice = i.MaxPrice,
                MinPrice = i.MinPrice
            }).ToListAsync();
        }

        public async Task<List<GetHotelDto>> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetCollcetionsAsync();
            return hotels.Select(i => new GetHotelDto
            {
                Id = i.Id,
                Name = i.Name,
                Address = i.Address,
                Latitude = i.Latitude,
                Longtitude = i.Longtitude,
                MaxPrice = i.MaxPrice,
                MinPrice = i.MinPrice
            }).ToList();
        }

        public async Task<bool> CreateHotel(CreateHotelDto input)
        {
            await _hotelRepository.CreateAsync(new Hotel
            {
                Address = input.Address,
                Latitude = input.Latitude,
                Longtitude = input.Longtitude,
                MaxPrice = input.MaxPrice,
                Name = input.Name,
                MinPrice = input.MinPrice
            });
            return await _hotelRepository.SaveChangesAsync();
        }

        public async Task<bool> UpdateHotel(int HotelId,UpdateHotelDto input)
        {
            var hotel = _hotelRepository.GetQuery(i => i.Id == HotelId).SingleOrDefault();
            if(hotel != null)
            {
                if (input.Address != null)
                    hotel.Address = input.Address;
                if (input.Name != null)
                    hotel.Name = input.Name;
                if (input.Address != null)
                    hotel.Address = input.Address;
                if (input.MinPrice != 0)
                    hotel.MinPrice = input.MinPrice;
                if (input.MaxPrice != 0)
                    hotel.MaxPrice = input.MaxPrice;
                if (input.Longtitude != null)
                    hotel.Longtitude = input.Longtitude;
                if (input.Latitude != null)
                    hotel.Latitude = input.Latitude;
                _hotelRepository.Update(hotel);
                return await _hotelRepository.SaveChangesAsync();
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteHotel(int hotelId)
        {
            var hotel = await _hotelRepository.GetQuery(i => i.Id == hotelId).SingleOrDefaultAsync();
            if (hotel == null)
                return false;
            _hotelRepository.Delete(hotel);
            return await _hotelRepository.SaveChangesAsync();
        }



    }
}
