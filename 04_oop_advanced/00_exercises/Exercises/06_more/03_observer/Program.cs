namespace More.Observer.P00_ChatGPTExample;
public class Program
{
    public static void Main()
    {
        var chelseaFC = new Subject("Chelsea FC");
        var liverpoolFC = new Subject("Liverpool FC");

        var frank = new Observer("Frank Lampard");
        var john = new Observer("John Terry");
        var fernando = new Observer("Fernando Torres");

        chelseaFC.Attach(frank);
        chelseaFC.Attach(john);
        chelseaFC.Attach(fernando);
        liverpoolFC.Attach(fernando);

        chelseaFC.UpdateState("Wins the PL Title!");
        liverpoolFC.UpdateState("Fires Jurgen Klopp!");
    }
}