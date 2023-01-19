using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Mappings;

public class UserMap: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");
    
        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnType("VARCHAR(100)");

        
        // builder
        //     .HasMany(c => c.Assignments)
        //     .WithOne(c => c.User)
        //     .HasForeignKey(c => c.UserId) // Se seguir o padrão de nomeclatura, essa instrução é opcional
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // builder
        //     .HasMany(c => c.AssignmentLists)
        //     .WithOne(c => c.User)
        //     .OnDelete(DeleteBehavior.Restrict);



    }
}