namespace Proxy_Pattern
{
    public class RealSubject : ISubject
    {
        public string Request(string request)
        {
            Console.WriteLine($"RealSubject: Обработка запроса '{request}'");
            return $"Результат для '{request}'";
        }
    }
}
