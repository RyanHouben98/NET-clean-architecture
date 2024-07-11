namespace NetCleanArchitecture.Domain.UnitTests;

public class TaskIdUnitTests
{
    [Fact]
    public void CreateUnique_Valid_ShouldReturnNewTaskId()
    {
        // Act
        var result = TaskId.CreateUnique();

        // Assert
        Assert.Multiple(() => {
            Assert.IsType<TaskListId>(result);
            Assert.NotEqual(Guid.NewGuid(), result.Value);
        });

    }

    [Fact]
    public void Create_Valid_ShouldReturnInitializedTaskId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = TaskId.Create(id);

        // Assert
        Assert.Multiple(() => {
            Assert.IsType<TaskListId>(result);
            Assert.Equal(id, result.Value);
        });
    }
}
