namespace Telephony.Models
{
    using Telephony.Models.Interfaces;
    public class StationaryPhone : ICallable
    {
        public string Call(string number)
        {
            return $"Dialing... {number}";
        }
    }
}
