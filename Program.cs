// See https://aka.ms/new-console-template for more information

using System.Net.WebSockets;

static void PrintInstanceCount<T>(string label)
{
    var count = typeof(T)
        .GetField("_instanceCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!
        .GetValue(null);
    Console.WriteLine($"\n{label} instances created: {count}\n");
}

Parallel.For(0, 2, i =>
{
    Console.WriteLine("NON THREAD-SAFE LOGGER");
    var log = Logger.GetInstance();
    log.Log($"Logging from iteration {i}");
});
PrintInstanceCount<Logger>("Logger");
// Console.WriteLine($"\nLogger instances created: {typeof(Logger).GetField("_instanceCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!.GetValue(null)}");
Console.WriteLine("");

Parallel.For(0, 2, i =>
{
    Console.WriteLine("THREAD-SAFE LOGGER WITH LOCK");
    var lock1 = LoggerLock.GetInstance();
    lock1.Log($"Logging from iteration {i}");
});
PrintInstanceCount<LoggerLock>("LoggerLock");
// Console.WriteLine($"\nLogger instances created: {typeof(LoggerLock).GetField("_instanceCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!.GetValue(null)}");
Console.WriteLine("");

Parallel.For(0, 2, i =>
{
    Console.WriteLine("THREAD-SAFE LOGGER WITH LAZY<T>");
    var lazy = LoggerLazy.GetInstance();
    lazy.Log($"Logging from iteration {i}");
});
PrintInstanceCount<LoggerLazy>("LoggerLazy");
// Console.WriteLine($"\nLogger instances created: {typeof(LoggerLazy).GetField("_instanceCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!.GetValue(null)}");
Console.WriteLine("");

Parallel.For(0, 2, i =>
{
    Console.WriteLine("THREAD-SAFE LOGGER WITH EAGER-LOADING");
    var eager = LoggerEager.GetInstance();
    eager.Log($"Logging from iteration {i}");
});   
PrintInstanceCount<LoggerEager>("LoggerEager");
// Console.WriteLine($"\nLogger instances created: {typeof(LoggerEager).GetField("_instanceCounter", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!.GetValue(null)}");

// Logger log = Logger.GetInstance();
// Logger log1 = Logger.GetInstance();

// LoggerLock lock1 = LoggerLock.GetInstance();
// LoggerLock lock2 = LoggerLock.GetInstance();

// LoggerLazy lazy = LoggerLazy.GetInstance();
// LoggerLazy lazy1 = LoggerLazy.GetInstance();

// LoggerEager eager = LoggerEager.GetInstance();
// LoggerEager eager1 = LoggerEager.GetInstance();

// Console.WriteLine("---------------NOT THREAD-SAFE Response----------------------");
// log.Log();
// log1.Log();
// Console.WriteLine(ReferenceEquals(log, log1));
// Console.WriteLine("---------------END----------------------");
// Console.WriteLine("");

// Console.WriteLine("---------------LOCK SAFE Response----------------------");
// lock1.Log();
// lock2.Log();
// Console.WriteLine(ReferenceEquals(lock1, lock2));
// Console.WriteLine("---------------END----------------------");
// Console.WriteLine("");

// Console.WriteLine("---------------LAZY<T> SAFE Response----------------------");
// lazy.Log();
// lazy1.Log();
// Console.WriteLine(ReferenceEquals(lazy, lazy1));
// Console.WriteLine("---------------END----------------------");
// Console.WriteLine("");

// Console.WriteLine("---------------EAGER INITIALIZATION SAFE Response----------------------");
// eager.Log();
// eager1.Log();
// Console.WriteLine(ReferenceEquals(eager, eager1));
// Console.WriteLine("---------------END----------------------");
// Console.WriteLine("");