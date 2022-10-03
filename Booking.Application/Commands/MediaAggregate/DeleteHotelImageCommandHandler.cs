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

namespace Booking.Application.Commands.MediaAggregate
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
            var imageExist = await _imageRepository.GetQuery(i => i.Id == request.ImageId).SingleOrDefaultAsync();
            if (imageExist != null)
            {
                var result = await _cloudinaryService.DeleteImage(imageExist.PublicId);
                _imageRepository.Delete(imageExist);
                return true;
            }
            else
                return false;
            
        }
    }
}
