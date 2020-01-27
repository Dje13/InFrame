using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketTransitionHisto
    {
        public long Id { get; set; }
        public long TicketId { get; set; }
        public long TransitionId { get; set; }
        public DateTime TransitionDate { get; set; }
        public string Comment { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual Transition Transition { get; set; }
    }
}
