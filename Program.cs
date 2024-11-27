using Proxy_Pattern;

public interface ISubject
{
    string Request(string request);
}

class Program
{
    static void Main(string[] args)
    {
        ISubject proxy = new Proxy();

        Console.WriteLine(proxy.Request("Запрос 1"));
        Console.WriteLine(proxy.Request("Запрос 1"));

        Thread.Sleep(11000); // кэш истек
        Console.WriteLine(proxy.Request("Запрос 1"));
    }
}