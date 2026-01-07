namespace Images_App.Application.DTOs
{
    public sealed class SaveImageRequest(
        string nombreArchivo,
        string tipoContenido,
        byte[] imageData)
    {
        public string NombreArchivo { get; init; } = nombreArchivo;
        public string TipoContenido { get; init; } = tipoContenido;
        public byte[] ImageData { get; init; } = imageData;
    }
}
