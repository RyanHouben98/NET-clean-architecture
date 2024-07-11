namespace NetCleanArchitecture.Domain.UnitTests;

public class TaskListUnitTests
{
    [Fact]
    public void Create_Valid_ShouldReturnNewTaskList()
    {
        // Arrange
        const string name = "Test task list";

        // Act
        var result = TaskList.Create(name);

        // Assert
        Assert.Multiple(() => {
            Assert.False(result.IsError);
            Assert.Equal(name, result.Value.Name);
        });
    }
}
