using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCleanArchitecture.Domain;
using Task = NetCleanArchitecture.Domain.Task;

namespace NetCleanArchitecture.Infrastructure;

public class TaskConfigurations : IEntityTypeConfiguration<Task>
{
    public void Configure(EntityTypeBuilder<Task> builder)
    {
        builder.HasKey(task => task.Id);
        builder.Property(task => task.Id)
            .ValueGeneratedNever()
            .HasConversion(
                task => task.Value,
                value => TaskId.Create(value));

        builder.Property(task => task.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(task => task.Description)
            .HasMaxLength(250)
            .IsRequired();

        builder.Property(task => task.IsCompleted);
    }
}
