using Booking.Application.Filters;
using Booking.Application.Model.MediaAggregate;
using Booking.Application.Services.Abstraction.MediaAggreagete;
using Booking.Domain.Entities.HotelAggregate;
using Booking.Infrastructure.Repository.Abstraction;
using Booking.Infrastructure.Repository.Implementation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Booking.Application.Commands.MediaAggregate.HotelAggregate
{
    public class UploadHotelImageCommandHandler : IRequestHandler<UploadHotelImageCommand, bool>
    {
        private readonly IHotelImageRepository _imageRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public UploadHotelImageCommandHandler(IHotelImageRepository imageRepository, ICloudinaryService cloudinaryService)
        {
            _imageRepository = imageRepository;
            _cloudinaryService = cloudinaryService;
        }


        public async Task<bool> Handle(UploadHotelImageCommand request, CancellationToken cancellationToken)
        {
            var uploadImage = await _cloudinaryService.UploadImage(request.File);
            await _imageRepository.CreateAsync(new HotelImages() { PublicId = uploadImage.PublicId, Url = uploadImage.Url.AbsoluteUri, HotelId = request.HotelId });
            var result = await _imageRepository.SaveChangesAsync();

            if (uploadImage == null)
            {
                throw new ImageNotUplaodedException("Image has not been uploaded" + (result == true ? "Image Added to database" : "Image has not been added to " +
                       "database!"));
            }
            return result;
        }
    }
}
