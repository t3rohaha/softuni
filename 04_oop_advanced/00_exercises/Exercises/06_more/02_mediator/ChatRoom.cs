namespace More.Mediator.P00_ChatRoom;
public class ChatRoom : IChatRoomMediator
{
    public void ShowMessage(User user, string message)
    {
        string time = DateTime.Now.ToString("HH:mm");
        string sender = user.Name;

        Console.WriteLine($"{time} {sender}: {message}");
    }
}
