public class LoggerLock
{
    private static LoggerLock? _instance = null;
    private static int _instanceCounter = 0;
    private static readonly object _lock = new object();

    private LoggerLock()
    {
        Interlocked.Increment(ref _instanceCounter);
        Console.WriteLine($"[Instance Created] Count: {_instanceCounter}");
    }

    public static LoggerLock GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    Thread.Sleep(10);
                    _instance = new LoggerLock();
                }
            }
        }        
        return _instance;
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {message}");
    }

}