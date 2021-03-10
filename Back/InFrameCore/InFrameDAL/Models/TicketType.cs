using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketType
    {
        public TicketType()
        {
            Ticket = new HashSet<Ticket>();
            TicketFormConfig = new HashSet<TicketFormConfig>();
            TicketListField = new HashSet<TicketListField>();
            TicketTypeTicketDynProp = new HashSet<TicketTypeTicketDynProp>();
        }

        public long Id { get; set; }
        public string TypeName { get; set; }
        public string TypeInternalName { get; set; }
        public string TypeShortName { get; set; }
        public string TypeDescription { get; set; }
        public string Icon { get; set; }
        public int Active { get; set; }
        public long WorkflowId { get; set; }

        public virtual WorkFlow Workflow { get; set; }
        public virtual ICollection<Ticket> Ticket { get; set; }
        public virtual ICollection<TicketFormConfig> TicketFormConfig { get; set; }
        public virtual ICollection<TicketListField> TicketListField { get; set; }
        public virtual ICollection<TicketTypeTicketDynProp> TicketTypeTicketDynProp { get; set; }
    }
}
