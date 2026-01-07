using Images_App.Domain.Entities;

namespace Images_App.Application.Interfaces
{
    public interface IImageRepository
    {
        internal Task SaveImageAsync(Image image);
    }
}
