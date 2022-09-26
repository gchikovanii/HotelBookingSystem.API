using Booking.Domain.Entities.Constant;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Booking.Application.Commands.RoomAggregate
{
    public class UpdateRoomCommand : IRequest<bool>
    {
        [Required]
        public int Id { get; set; }
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
    }
}
