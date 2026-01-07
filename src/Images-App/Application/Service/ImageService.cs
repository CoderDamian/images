using Images_App.Application.DTOs;
using Images_App.Application.UseCases.Interfaces;

namespace Images_App.Application.Service
{
    public class ImageService
    {
        private readonly ISaveImageUseCase _saveImageUseCase;

        public ImageService(
            ISaveImageUseCase saveImageUseCase) 
        {
            this._saveImageUseCase = saveImageUseCase;
        }

        public async Task SaveImageAsync(SaveImageRequest saveImageRequest)
        {
            await _saveImageUseCase.ExecuteAsync(saveImageRequest).ConfigureAwait(false);
        }
    }
}
