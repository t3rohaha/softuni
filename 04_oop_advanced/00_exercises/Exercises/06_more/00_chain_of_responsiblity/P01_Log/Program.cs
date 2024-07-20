using More.ChainOfResponsibility.P01_Log.Models;

namespace More.ChainOfResponsibility.P01_Log;
public class Program
{
    public static void Main()
    {
        LogHandler head = new InfoLogHandler();
        LogHandler warning = new WarningLogHandler();
        LogHandler error = new ErrorLogHandler();

        head.SetNext(warning);
        warning.SetNext(error);

        head.Handle("This is info.", "info");
        head.Handle("This is WARNING!", "warning");
        head.Handle("This is ERROR! x(", "error");
        head.Handle("idk", "idk");
    }
}