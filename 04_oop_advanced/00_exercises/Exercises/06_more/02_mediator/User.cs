namespace More.Mediator.P00_ChatRoom;
public class User
{
    private IChatRoomMediator _mediator;

    public User(string name, IChatRoomMediator mediator)
    {
        this.Name = name;
        _mediator = mediator;
    }
    public string Name { get; private set; }

    public void SendMessage(string message)
    {
        _mediator.ShowMessage(this, message);
    }
}