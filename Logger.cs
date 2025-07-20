public class Logger
{
    private static Logger? _instance = null;//one & only logger object & IS NULL AT FIRST - WE CANT >> Logger logger = new Logger();
    private static int _instanceCounter = 0;

    private Logger()//private constructor preventing the instantiation of the class
    {
        Interlocked.Increment(ref _instanceCounter);
        Console.WriteLine($"[Instance Created] Count: {_instanceCounter}");
    }
    public static Logger GetInstance()//PROPERTY WHICH IS THE ONLY WAY TO ACCESS THE OBJECT
    {
        if (_instance == null)
        {
            //Thread.Sleep(10);// Simulate delay to increase the chance of race condition
            _instance = new Logger();
        }
        return _instance;
    }

    public void Log(string message)//METHOD THAT USES LOGGER
    {
        Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}] {message}");
    }
    
}