using Images_App.Domain.Exceptions;

namespace Images_App.Domain.Entities
{
    internal class Image
    {
        public int Id { get; private set; }
        public string NombreArchivo { get; private set; } = string.Empty;
        public string TipoContenido { get; private set; } = string.Empty;
        public byte[] ImageData { get; private set; } = [];
        public int TamanoArchivo { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Image(
            string nombreArchivo, 
            string tipoContenido, 
            byte[] imageData)
        {
            if (string.IsNullOrEmpty(nombreArchivo))
                throw new DomainException("El nombre del archivo es requerido");

            if (string.IsNullOrEmpty(tipoContenido))
                throw new DomainException("El nombre de la extension del archivo es requerido");

            if  (imageData is null || imageData.Length == 0)
                throw new DomainException("El tamaño del archivo no puede ser 0");

            this.NombreArchivo = nombreArchivo;
            this.TipoContenido = tipoContenido;
            this.ImageData = imageData;
            this.TamanoArchivo = imageData.Length;
            this.CreatedAt = DateTime.Now;
        }
    }
}
