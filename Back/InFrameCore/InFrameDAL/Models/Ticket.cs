using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            TicketDynPropValue = new HashSet<TicketDynPropValue>();
            TicketDynPropValueHisto = new HashSet<TicketDynPropValueHisto>();
            TicketTransitionHisto = new HashSet<TicketTransitionHisto>();
        }

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

        public virtual TicketType Type { get; set; }
        public virtual ICollection<TicketDynPropValue> TicketDynPropValue { get; set; }
        public virtual ICollection<TicketDynPropValueHisto> TicketDynPropValueHisto { get; set; }
        public virtual ICollection<TicketTransitionHisto> TicketTransitionHisto { get; set; }
    }
}
