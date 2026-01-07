using Images_App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Images_App.DataPersistence.Mappings
{
    public class ImageMap : IEntityTypeConfiguration<Image>
    {
        void IEntityTypeConfiguration<Image>.Configure(EntityTypeBuilder<Image> builder)
        {
            builder.ToTable("IMAGES", "CTB");

            builder.Property(p => p.Id)
                .HasColumnName("IMAGE_ID");

            builder.Property(p => p.NombreArchivo)
                .HasColumnName("FILE_NAME");

            builder.Property(p => p.TipoContenido)
                .HasColumnName("CONTENT_TYPE");

            builder.Property(p => p.ImageData)
                .HasColumnName("IMAGE_DATA");

            builder.Property(p => p.TamanoArchivo)
                .HasColumnName("FILE_SIZE");

            builder.Property(p => p.CreatedAt)
                .HasColumnName("CREATED_AT");
        }
    }
}
