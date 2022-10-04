using Booking.Application.Filters;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using Booking.Infrastructure.Repository.Abstraction;
using CloudinaryDotNet.Actions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.RoomAggregate
{
    public class DeleteRoomImageCommandHandler : IRequestHandler<DeleteRoomImageCommand, bool>
    {
        private readonly IRoomImagesRepository _imagesRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public DeleteRoomImageCommandHandler(IRoomImagesRepository imagesRepository, ICloudinaryService cloudinaryService)
        {
            _cloudinaryService = cloudinaryService;
            _imagesRepository = imagesRepository;
        }
        public async Task<bool> Handle(DeleteRoomImageCommand request, CancellationToken cancellationToken)
        {
            var roomImages = await _imagesRepository.GetQuery(i => i.Id == request.RoomImageId).SingleOrDefaultAsync();
            var deleteImageFromCloudinary = await _cloudinaryService.DeleteImage(roomImages.PublicId);

            _imagesRepository.Delete(roomImages);
            var result = await _imagesRepository.SaveChangesAsync();
            if (deleteImageFromCloudinary == null)
                throw new ImageNotDeletedException("Image has not been deleted from cloudinary" + (result == true ? "Image Deleted from database" : "Image has not been deleted from" +
                    "database!"));
            return await _imagesRepository.SaveChangesAsync();
        }
    }
}
