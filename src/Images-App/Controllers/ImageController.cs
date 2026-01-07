using Images_App.Application.DTOs;
using Images_App.Application.Service;
using Images_App.Controllers.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Images_App.Controllers
{
    [ApiController]
    [Route("api/images")]
    public class ImageController : ControllerBase
    {
        private readonly ImageService _imageService;

        public ImageController(ImageService imageService)
        {
            this._imageService = imageService;
        }

        [HttpPost(Name = "save-an-image")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Save([FromForm] SaveImageForm form)
        {
            if (form.Image is null || form.Image.Length == 0)
                return BadRequest("Image file is required.");

            using var memoryStream = new MemoryStream();
            await form.Image.CopyToAsync(memoryStream);

            var saveImageRequest = new SaveImageRequest(
                nombreArchivo: form.NombreArchivo,
                tipoContenido: form.TipoContenido,
                imageData: memoryStream.ToArray());

            await _imageService.SaveImageAsync(saveImageRequest).ConfigureAwait(false);

            return Ok();
        }
    }
}
