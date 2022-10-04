using Booking.Application.Filters;
using Booking.Application.Model.MediaAggregate;
using Booking.Application.Model.RoomAggregate;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using Booking.Application.Services.Implementation.MediaAggreagete;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using CloudinaryDotNet.Actions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.RoomAggregate
{
    internal class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, bool>
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ICloudinaryService _cloudinaryService;
        private readonly IRoomImagesRepository _imagesRepository;
        public CreateRoomCommandHandler(IRoomRepository roomRepository, ICloudinaryService cloudinaryService, IRoomImagesRepository imagesRepository)
        {
            _roomRepository = roomRepository;
            _cloudinaryService = cloudinaryService;
            _imagesRepository = imagesRepository;
        }
        public async Task<bool> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var room = new Room()
            {
                Sofa = request.Sofa,
                AirConditioner = request.AirConditioner,
                Balcony = request.Balcony,
                BedType = request.BedType,
                RoomType = request.RoomType,
                CoffeMachine = request.CoffeMachine,
                TV = request.TV,
                Fridge = request.Fridge,
                MiniBar = request.MiniBar,
                HotelId = request.HotelId,
                NumberOfRooms = request.NumberOfRooms
            };
            await _roomRepository.CreateAsync(room);
            var result = await _roomRepository.SaveChangesAsync();

            var imageResult = await UplaodImages(request.GetImageFiles().Select(i => new CreateRoomImagesDto()
            {
                File = i,
                RoomId = room.Id
            }).ToList());

            if (!imageResult)
            {
                throw new ImageNotUplaodedException("Image has not been uploaded!" + (result == true ? "Room has been added succesfully!" : "Room has not been added"));
            }

            return result;
        }


        private async Task<bool> UplaodImages(List<CreateRoomImagesDto> input)
        {
            List<Task<ImageUploadResult>> imageUploadResults = new List<Task<ImageUploadResult>>();
            foreach (var item in input)
            {
                imageUploadResults.Add(_cloudinaryService.UploadImage(item.File));
            }
            var uploadImages = await Task.WhenAll(imageUploadResults);

            foreach (var image in uploadImages)
            {
                await _imagesRepository.CreateAsync(new RoomImages()
                {
                    RoomId = input.FirstOrDefault().RoomId,
                    PublicId = image.PublicId,
                    Url = image.Url.AbsoluteUri
                });
            }
            return await _roomRepository.SaveChangesAsync();
        }

    }
}
