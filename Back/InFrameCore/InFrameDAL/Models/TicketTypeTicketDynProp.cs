using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketTypeTicketDynProp
    {
        public long Id { get; set; }
        public long DynPropId { get; set; }
        public long TypeId { get; set; }
        public int Active { get; set; }

        public virtual TicketDynProp DynProp { get; set; }
        public virtual TicketType Type { get; set; }
    }
}
