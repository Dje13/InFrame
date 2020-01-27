using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameDAL.DTO
{
    public class TicketDTO
    {
        public long Id { get; set; }
        public long TypeId { get; set; }
        public string TicketTitle { get; set; }
        public string TicketContent { get; set; }
        public long TicketStatus { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? CloseDate { get; set; }
        public int Criticality { get; set; }
        public string Project { get; set; }

        public Dictionary<string, object> dynPropValues { get; set; }
    }
}
