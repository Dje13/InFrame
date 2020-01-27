using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketDynProp
    {
        public TicketDynProp()
        {
            TicketDynPropValue = new HashSet<TicketDynPropValue>();
            TicketDynPropValueHisto = new HashSet<TicketDynPropValueHisto>();
            TicketTypeTicketDynProp = new HashSet<TicketTypeTicketDynProp>();
        }

        public long Id { get; set; }
        public string DynPropName { get; set; }
        public string DynPropType { get; set; }
        public int Active { get; set; }

        public virtual ICollection<TicketDynPropValue> TicketDynPropValue { get; set; }
        public virtual ICollection<TicketDynPropValueHisto> TicketDynPropValueHisto { get; set; }
        public virtual ICollection<TicketTypeTicketDynProp> TicketTypeTicketDynProp { get; set; }
    }
}
