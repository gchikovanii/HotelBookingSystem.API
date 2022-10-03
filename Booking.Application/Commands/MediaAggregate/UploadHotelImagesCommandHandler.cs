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

namespace Booking.Application.Commands.MediaAggregate
{
    public class UploadHotelImagesCommandHandler : IRequestHandler<UploadHotelImagesCommand, bool>
    {
        private readonly IHotelImageRepository _imageRepository;
        private readonly ICloudinaryService _cloudinaryService;
        public UploadHotelImagesCommandHandler(IHotelImageRepository imageRepository, ICloudinaryService cloudinaryService)
        {
            _imageRepository = imageRepository;
            _cloudinaryService = cloudinaryService;
        }


        public async Task<bool> Handle(UploadHotelImagesCommand request, CancellationToken cancellationToken)
        {
            var result = await _cloudinaryService.UploadImage(request.File);
            await _imageRepository.CreateAsync(new HotelImages() { PublicId = result.PublicId, Url = result.Url.AbsoluteUri, HotelId = request.HotelId });
            return await _imageRepository.SaveChangesAsync();
        }
    }
}
