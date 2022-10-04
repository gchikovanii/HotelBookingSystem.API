using Booking.Application.Filters;
using Booking.Application.Model.MediaAggregate;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using Booking.Domain.Entities.RoomAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.RoomAggregate
{
    public class UploadRoomImagesCommandHandler : IRequestHandler<UploadRoomImagesCommand, bool>
    {
        private readonly IRoomImagesRepository _imagesRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public UploadRoomImagesCommandHandler(IRoomImagesRepository imagesRepository, ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
            _imagesRepository = imagesRepository;
        }

        public async Task<bool> Handle(UploadRoomImagesCommand request, CancellationToken cancellationToken)
        {
            var uploadImage = await _cloudinaryService.UploadImage(request.File);
            await _imagesRepository.CreateAsync(new RoomImages() { RoomId = request.RoomId, PublicId = uploadImage.PublicId, Url = uploadImage.Url.AbsoluteUri });
            var result = await _imagesRepository.SaveChangesAsync();
            if(uploadImage != null)
            {
                throw new ImageNotUplaodedException("Image has not been uploaded" + (result == true ? "Image Added to database" : "Image has not been added to " +
                       "database!"));
            }
            return result;

        }
    }
}
