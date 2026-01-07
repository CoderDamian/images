namespace Images_App.Controllers.DTOs
{
    public sealed class SaveImageForm
    {
        public required string NombreArchivo { get; init; }
        public required string TipoContenido { get; init; }
        public required IFormFile Image { get; init; }
    }
}
