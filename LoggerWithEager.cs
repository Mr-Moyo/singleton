public class LoggerEager
{
    private static int _instanceCounter = 0;
    private static readonly LoggerEager _instance = new LoggerEager();
    private LoggerEager()
    {
        Interlocked.Increment(ref _instanceCounter);
        Console.WriteLine($"[Instance Created] Count: {_instanceCounter}");
    }

    public static LoggerEager GetInstance()
    {
        return _instance;
    }
    public void Log(string message)
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {message}");
    }
}