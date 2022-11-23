namespace Telephony.Models
{
    using Telephony.Models.Interfaces;
    public class Smartphone : IBrowseable, ICallable
    {
        public string BrowseURL(string url)
        {
            return $"Browsing: {url}!";
        }

        public string Call(string number)
        {
            return $"Calling... {number}";
        }
    }
}
