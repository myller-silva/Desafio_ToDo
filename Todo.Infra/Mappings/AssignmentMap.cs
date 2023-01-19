using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Mappings;

public class AssignmentMap: IEntityTypeConfiguration<Assignment>
{
    public void Configure(EntityTypeBuilder<Assignment> builder)
    {
        builder.ToTable("assignment");
        builder.HasKey( x => x.Id );
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasColumnType("VARCHAR(101)");

        builder.Property(x => x.UserId)
            .IsRequired();
        builder.Property(x => x.AssignmentListId)
            .IsRequired(false);
        builder.Property(x => x.Concluded)
            .IsRequired()
            .HasDefaultValue(false); //???
        
        
        


    }
}