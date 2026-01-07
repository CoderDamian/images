using Images_App.Application.DTOs;
using Images_App.Application.Interfaces;
using Images_App.Application.UseCases.Interfaces;
using Images_App.Domain.Entities;

namespace Images_App.Application.UseCases
{
    public class SaveImageUseCase : ISaveImageUseCase
    {
        private readonly IImageRepository _imageRepository;

        public SaveImageUseCase(IImageRepository imageRepository)
        {
            this._imageRepository = imageRepository;
        }

        public async Task ExecuteAsync(SaveImageRequest request)
        {
            var image = new Image(
                nombreArchivo: request.NombreArchivo,
                tipoContenido: request.TipoContenido,
                imageData: request.ImageData);

            await _imageRepository.SaveImageAsync(image);
        }
    }
}
