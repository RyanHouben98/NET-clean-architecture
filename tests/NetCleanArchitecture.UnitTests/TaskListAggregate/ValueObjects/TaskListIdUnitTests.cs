namespace NetCleanArchitecture.Domain.UnitTests;

public class TaskListIdUnitTests
{
    [Fact]
    public void CreateUnique_Valid_ShouldReturnNewTaskListId()
    {
        // Act
        var result = TaskListId.CreateUnique();

        // Assert
        Assert.Multiple(() => {
            Assert.IsType<TaskListId>(result);
            Assert.NotEqual(Guid.NewGuid(), result.Value);
        });

    }

    [Fact]
    public void Create_Valid_ShouldReturnInitializedTaskListId()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var result = TaskListId.Create(id);

        // Assert
        Assert.Multiple(() => {
            Assert.IsType<TaskListId>(result);
            Assert.Equal(id, result.Value);
        });
    }
}
