namespace ResourceCloud.Tests;

public class DepartmentCloudTests
{
    private DepartmentCloud _cloud;

    public DepartmentCloudTests()
    {
        _cloud = new DepartmentCloud();
    }

    [Fact]
    public void LogTask_ValidParams_ShouldAddTaskSuccessfully()
    {
        var actualMessage = _cloud.LogTask(["1", "Task1", "Resource1"]);
        var actualCount = _cloud.Tasks.Count();

        var expectedMessage = "Task logged successfully.";
        var expectedCount = 1;

        Assert.Equal(expectedMessage, actualMessage);
        Assert.Equal(expectedCount, actualCount);
    }

    [Fact]
    public void LogTask_InvalidParamsCount_ShouldThrowException()
    {
        var result = () => { _cloud.LogTask([]); };

        var actual = Assert.Throws<ArgumentException>(result);
        var expected = "All arguments are required.";

        Assert.Equal(actual.Message, expected);
    }

    #nullable disable
    [Fact]
    public void LogTask_ParamsContainNull_ShouldThrowException()
    {
        var result = () => { _cloud.LogTask([null, null, null]); };

        var actual = Assert.Throws<ArgumentException>(result);
        var expected = "Arguments values cannot be null.";

        Assert.Equal(expected, actual.Message);
    }
    #nullable enable

    [Fact]
    public void LogTask_TaskAlreadyExists_ShouldNotAddDuplicate()
    {
        _cloud.LogTask(["1", "Task1", "Resource1"]);

        var actual = _cloud.LogTask(["1", "Task1", "Resource1"]);
        var expected = "Resource1 is already logged.";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateResource_SuccessfullCreate_ShouldReturnTrue()
    {
        _cloud.LogTask(["1", "Task1", "Resource1"]);

        var actual = _cloud.CreateResource();

        Assert.True(actual);
    }

    [Fact]
    public void CreateResource_SuccessfullCreate_ShouldAddResource()
    {
        _cloud.LogTask(["1", "Task1", "Resource1"]);

        _cloud.CreateResource();

        var resource = _cloud.Resources.FirstOrDefault()!;

        var actual = resource.Name;

        var expected = "Resource1";

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateResource_SuccessfullCreate_ShouldRemoveTask()
    {
        _cloud.LogTask(["1", "Task1", "Resource1"]);

        _cloud.CreateResource();

        var actual = _cloud.Tasks.Count();

        var expected = 0;

        Assert.Equal(expected, actual);
    }

    [Fact]
    public void CreateResource_NoTasks_ShouldReturnFalse()
    {
        var actual = _cloud.CreateResource();

        Assert.False(actual);
    }

    [Fact]
    public void TestResource_ResourceExists_ShouldChangeResourceTestedPropertyToTrue()
    {
        _cloud.LogTask(["1", "Task1", "Resource1"]);

        _cloud.CreateResource();

        var actual = _cloud.TestResource("Resource1")!;

        Assert.True(actual.IsTested);
    }

    [Fact]
    public void TestResource_InvalidResourceName_ShouldReturnNull()
    {
        var actual = _cloud.TestResource("Resource1");

        Assert.Null(actual);
    }
}