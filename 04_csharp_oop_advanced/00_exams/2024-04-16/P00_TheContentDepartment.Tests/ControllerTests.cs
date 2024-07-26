using System.Text;
using TheContentDepartment.Core;

namespace TheContentDepartment.Tests;
public class ControllerTests
{
    [Fact]
    public void ValidateExampleOutput()
    {
        var controller = new Controller();

        var sb = new StringBuilder();

        // Test JoinTeam()
        sb.AppendLine(controller.JoinTeam("TeamLead", "YokoYong", "Master"));
        sb.AppendLine(controller.JoinTeam("ContentMember", "DaniDavis", "JavaScript"));
        sb.AppendLine(controller.JoinTeam("ContentMember", "DaniDavis", "Java"));
        sb.AppendLine(controller.JoinTeam("ContentMember", "PeterSully", "Java"));
        sb.AppendLine(controller.JoinTeam("ContentMember", "ValGendor", "Python"));

        // Test CreateResource()
        sb.AppendLine(controller.CreateResource("Presentation", "Inheritance", "CSharp"));

        // Test JoinTeam()
        sb.AppendLine(controller.JoinTeam("ContentMember", "KrissThompson", "CSharp"));
        sb.AppendLine(controller.JoinTeam("TrainingMember", "DenisPeters", "CSharp"));
        sb.AppendLine(controller.JoinTeam("ContentMember", "ValGendor", "Java"));

        // Test CreateResource()
        sb.AppendLine(controller.CreateResource("Lab", "LabDocument", "CSharp"));
        sb.AppendLine(controller.CreateResource("Exam", "JavaScriptOOP-Retake", "JavaScript"));
        sb.AppendLine(controller.CreateResource("Workshop", "TicTacToe", "Python"));
        sb.AppendLine(controller.CreateResource("Exam", "JavaScriptOOP-Regular", "JavaScript"));
        sb.AppendLine(controller.CreateResource("Exam", "JavaScriptOOP-Regular", "JavaScript"));
        sb.AppendLine(controller.CreateResource("Exam", "JavaOOP-Regular", "Java"));
        sb.AppendLine(controller.CreateResource("VideoContent", "WelcomeVideo", "Java"));
        sb.AppendLine(controller.CreateResource("Exam", "JavaOOP-Retake", "Java"));
        sb.AppendLine(controller.CreateResource("WorkShop", "Regex-Exercise", "Python"));
        sb.AppendLine(controller.CreateResource("Presentation", "Inheritance", "CSharp"));
        sb.AppendLine(controller.CreateResource("Exam", "C#OOP-Regular", "CSharp"));

        // Test LogTesting()
        sb.AppendLine(controller.LogTesting("DenisPeters"));
        sb.AppendLine(controller.LogTesting("ValGendor"));
        sb.AppendLine(controller.LogTesting("ValGendor"));
        sb.AppendLine(controller.LogTesting("ValGendor"));
        sb.AppendLine(controller.LogTesting("DannyDavis"));
        sb.AppendLine(controller.LogTesting("PeterSully"));
        sb.AppendLine(controller.LogTesting("PeterSully"));
        sb.AppendLine(controller.LogTesting("KrissThompson"));

        // Test ApproveResource()
        sb.AppendLine(controller.ApproveResource("JavaOOP-Regular", true));
        sb.AppendLine(controller.ApproveResource("JavaOOP-Retake", false));
        sb.AppendLine(controller.ApproveResource("Inheritance", true));
        sb.AppendLine(controller.ApproveResource("C#OOP-Regular", true));
        sb.AppendLine(controller.ApproveResource("TicTacToe", true));
        sb.AppendLine(controller.ApproveResource("JavaScriptOOP-Retake", true));

        // Test DepartmentReport()
        sb.AppendLine(controller.DepartmentReport());

        var actualResult = sb.ToString().Trim();

        var expectedResult = "YokoYong has joined the team. Welcome!\nDaniDavis has joined the team. Welcome!\nDaniDavis has already joined the team.\nPeterSully has joined the team. Welcome!\nValGendor has joined the team. Welcome!\nNo content member is able to create the Inheritance resource.\nKrissThompson has joined the team. Welcome!\nTrainingMember is not a valid member type.\nPosition is occupied.\nLab type is not handled by Content Department.\nDaniDavis created Exam - JavaScriptOOP-Retake.\nValGendor created Workshop - TicTacToe.\nDaniDavis created Exam - JavaScriptOOP-Regular.\nThe JavaScriptOOP-Regular resource is being created.\nPeterSully created Exam - JavaOOP-Regular.\nVideoContent type is not handled by Content Department.\nPeterSully created Exam - JavaOOP-Retake.\nWorkShop type is not handled by Content Department.\nKrissThompson created Presentation - Inheritance.\nKrissThompson created Exam - C#OOP-Regular.\nProvide the correct member name.\nTicTacToe is tested and ready for approval.\nValGendor has no resources for testing.\nValGendor has no resources for testing.\nProvide the correct member name.\nJavaOOP-Regular is tested and ready for approval.\nJavaOOP-Retake is tested and ready for approval.\nC#OOP-Regular is tested and ready for approval.\nYokoYong approved JavaOOP-Regular.\nYokoYong returned JavaOOP-Retake for a re-test.\nInheritance cannot be approved without being tested.\nYokoYong approved C#OOP-Regular.\nYokoYong approved TicTacToe.\nJavaScriptOOP-Retake cannot be approved without being tested.\nFinished Tasks:\n--TicTacToe (Workshop), Created By: ValGendor\n--JavaOOP-Regular (Exam), Created By: PeterSully\n--C#OOP-Regular (Exam), Created By: KrissThompson\nTeam Report:\n--YokoYong (TeamLead) - Currently working on 1 tasks.\nDaniDavis - JavaScript path. Currently working on 2 tasks.\nPeterSully - Java path. Currently working on 0 tasks.\nValGendor - Python path. Currently working on 0 tasks.\nKrissThompson - CSharp path. Currently working on 1 tasks.";

        Assert.Equal(expectedResult, actualResult);
    }
}