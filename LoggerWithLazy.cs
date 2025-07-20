public class LoggerLazy
{
    private static readonly Lazy<LoggerLazy> _instance = new Lazy<LoggerLazy>(() => new LoggerLazy());
    private static int _instanceCounter = 0;
    private LoggerLazy()
    {
        Interlocked.Increment(ref _instanceCounter);
        Console.WriteLine($"[Instance Created] Count: {_instanceCounter}");
    }

    public static LoggerLazy GetInstance()
    {
        return _instance.Value;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {message}");
    }
}