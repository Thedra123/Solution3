using System;
using System.Collections.Generic;

namespace Concat.API.Model
{
    public class GotTicket
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Order { get; set; }
        public DateTime TicketTime { get; set; } = DateTime.Now;
        public bool IsExpired { get; set; } = false; 
    }
}