using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetCleanArchitecture.Domain;

namespace NetCleanArchitecture.Infrastructure;

public class TaskListConfiguration : IEntityTypeConfiguration<TaskList>
{
    public void Configure(EntityTypeBuilder<TaskList> builder)
    {
        builder.HasKey(taskList => taskList.Id);
        builder.Property(taskList => taskList.Id)
            .HasConversion(
                taskList => taskList.Value,
                value => TaskListId.Create(value));

        builder.Property(taskList => taskList.Name)
            .HasMaxLength(100)
            .IsRequired();
    }
}
