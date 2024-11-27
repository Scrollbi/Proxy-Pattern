namespace Proxy_Pattern
{
    public class Proxy : ISubject
    {
        private RealSubject _realSubject;
        private Dictionary<string, (string Result, DateTime Expiration)> _cache;
        private TimeSpan _cacheDuration;

        public Proxy()
        {
            _realSubject = new RealSubject();
            _cache = new Dictionary<string, (string Result, DateTime Expiration)>();
            _cacheDuration = TimeSpan.FromSeconds(10); 
        }

        public string Request(string request)
        {
            if (!func()) return "Доступ запрещен";
            
            if (_cache.TryGetValue(request, out var cachedResult))
            {
                if (DateTime.Now < cachedResult.Expiration)
                {
                    Console.WriteLine("proxy: Возврат результата из кэша.");
                    return cachedResult.Result;
                }
                else _cache.Remove(request);
                
            }

            string result = _realSubject.Request(request);
            _cache[request] = (result, DateTime.Now.Add(_cacheDuration));
            return result;
        }

        private bool func()
        {
            return true;
        }
    }
}
