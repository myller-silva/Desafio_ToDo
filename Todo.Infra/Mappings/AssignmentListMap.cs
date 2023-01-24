using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Domain.Entities;

namespace Todo.Infra.Mappings;

public class AssignmentListMap: IEntityTypeConfiguration<AssignmentList>
{
    public void Configure(EntityTypeBuilder<AssignmentList> builder)
    {
        builder.ToTable("AssignmentList");
        builder.HasKey(x => x.Id);
        
        builder.Property(x=>x.Name)
            .IsRequired() //deixo falso ou nao?
            .HasColumnType("VARCHAR(50)");
        
        builder.Property(x=>x.UserId)
            .IsRequired();
        
        
    }
}