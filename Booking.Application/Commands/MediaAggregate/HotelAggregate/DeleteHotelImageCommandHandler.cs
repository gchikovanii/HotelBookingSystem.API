using Booking.Application.Filters;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using Booking.Infrastructure.Repository.Abstraction;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.HotelAggregate
{
    public class DeleteHotelImageCommandHandler : IRequestHandler<DeleteHotelImageCommand, bool>
    {
        private readonly IHotelImageRepository _imageRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public DeleteHotelImageCommandHandler(IHotelImageRepository imageRepository, ICloudinaryService cloudinaryService)
        {
            _imageRepository = imageRepository;
            _cloudinaryService = cloudinaryService;
        }
        public async Task<bool> Handle(DeleteHotelImageCommand request, CancellationToken cancellationToken)
        {
            var hotelImage = await _imageRepository.GetQuery(i => i.Id == request.HotelImageId).FirstOrDefaultAsync();
            var imageResult = await _cloudinaryService.DeleteImage(hotelImage.PublicId);
            _imageRepository.Delete(hotelImage);
            var result = await _imageRepository.SaveChangesAsync();
            if (imageResult == null)
                throw new ImageNotDeletedException("Image has not been deleted from cloudinary" + (result == true ? "Image Deleted from database" : "Image has not been deleted from" +
                    "database!"));
            return result;

        }
    }
}
