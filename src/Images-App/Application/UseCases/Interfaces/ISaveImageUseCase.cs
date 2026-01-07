using Images_App.Application.DTOs;

namespace Images_App.Application.UseCases.Interfaces
{
    public interface ISaveImageUseCase
    {
        Task ExecuteAsync(SaveImageRequest request);
    }
}
