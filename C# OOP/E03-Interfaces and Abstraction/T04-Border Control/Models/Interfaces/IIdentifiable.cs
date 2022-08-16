namespace BorderControl.Models.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    public interface IIdentifiable
    {
        string Id { get; set; }
        //string CheckIdentity(string identity);
    }
}
