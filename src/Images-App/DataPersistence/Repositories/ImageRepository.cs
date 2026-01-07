using Images_App.Application.Interfaces;
using Images_App.Domain.Entities;

namespace Images_App.DataPersistence.Repositories
{
    internal class ImageRepository : IImageRepository
    {
        private readonly MyDBContext _myDBContext;

        public ImageRepository(MyDBContext myDBContext)
        {
            this._myDBContext = myDBContext;
        }

        async Task IImageRepository.SaveImageAsync(Image image)
        {
            _myDBContext.Images.Add(image);
            await _myDBContext.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
