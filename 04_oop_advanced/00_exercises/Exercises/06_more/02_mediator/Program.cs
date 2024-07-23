namespace More.Mediator.P00_ChatRoom;
public class Program
{
    public static void Main()
    {
        IChatRoomMediator mediator = new ChatRoom();

        var user1 = new User("Frank Lampard", mediator);
        var user2 = new User("John Terry", mediator);

        user1.SendMessage("Hello John!");
        user2.SendMessage("Hello Frank!");
    }
}