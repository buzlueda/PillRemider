using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PillReminder.Core.Domain.Entities;

namespace PillReminder.Infrastructure.Persistence.Configs;

public class CategoryConfig : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(x => x.Id).HasName("PK_Categories");

        builder.Property(x => x.Id).HasColumnName("CategoryId");
        builder.Property(x => x.Name).HasColumnName("Name").IsRequired();
        builder.Property(x => x.Description).HasColumnName("Description");

        builder.Property(x => x.CreatedAt).HasColumnName("CreatedAt").IsRequired();
        builder.Property(x => x.ModifiedAt).HasColumnName("ModifiedAt");
        builder.Property(x => x.DeletedAt).HasColumnName("DeletedAt");

        builder.HasQueryFilter(x => !x.DeletedAt.HasValue);

        builder.HasMany(x => x.Medications)
            .WithOne(x => x.Category)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Category { Id = 1, Name = "Ağrı Kesiciler", Description = "Baş ağrısı, kas ağrısı, romatizma gibi ağrılar için ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 2, Name = "Antibiyotikler", Description = "Bakteriyel enfeksiyonları tedavi eden ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 3, Name = "Vitaminler & Takviyeler", Description = "Bağışıklık sistemini güçlendiren vitamin ve besin takviyeleri", CreatedAt = DateTime.UtcNow },
            new Category { Id = 4, Name = "Antidepresanlar", Description = "Depresyon, anksiyete ve diğer psikiyatrik rahatsızlıklar için ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 5, Name = "Alerji İlaçları", Description = "Alerji semptomlarını hafifletmek için kullanılan ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 6, Name = "Diyabet İlaçları", Description = "Şeker hastalığının yönetimi için ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 7, Name = "Tansiyon İlaçları", Description = "Yüksek tansiyonu kontrol altına almak için ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 8, Name = "Soğuk Algınlığı & Grip", Description = "Soğuk algınlığı ve grip semptomlarını hafifletici ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 9, Name = "Mide & Sindirim Sistemi", Description = "Mide yanması, reflü, hazımsızlık gibi sorunlar için ilaçlar", CreatedAt = DateTime.UtcNow },
            new Category { Id = 10, Name = "Cilt Hastalıkları İçin", Description = "Egzama, sedef hastalığı ve akne gibi cilt hastalıkları için ilaçlar", CreatedAt = DateTime.UtcNow }
        );
    }
}
