using Booking.Applcation.Extensions;
using Booking.Domain.Entities.Constant;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.OrderAggregate;
using Booking.Domain.Entities.RoomAggregate;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace Booking.Application.Commands.RoomAggregate
{
    public class CreateRoomCommand : IRequest<bool>
    {
        [Required]
        public bool Fridge { get; set; }
        [Required]
        public bool MiniBar { get; set; }
        [Required]
        public bool Sofa { get; set; }
        [Required]
        public bool TV { get; set; }
        [Required]
        public bool AirConditioner { get; set; }
        [Required]
        public bool CoffeMachine { get; set; }
        [Required]
        public bool Balcony { get; set; }
        [Required]
        public BedType BedType { get; set; }
        [Required]
        public RoomType RoomType { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }

        public List<string> Images { get; set; }
        public List<IFormFile> GetImageFiles()
        {
            try
            {
                var imageFiles = new List<IFormFile>();
                if (Images.Count == 0 || Images == null)
                    return default;
                foreach (var image in Images)
                {
                    imageFiles.Add(image.Base64ToImage());
                }
                return imageFiles;
            }
            catch (Exception)
            {
                return default;
            }
        }
    }
}
