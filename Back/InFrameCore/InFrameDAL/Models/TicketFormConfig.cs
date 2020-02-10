using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TicketFormConfig
    {
        public TicketFormConfig()
        {
            TicketFormGroup = new HashSet<TicketFormGroup>();
        }

        public long Id { get; set; }
        public long TicketTypeId { get; set; }
        public string Title { get; set; }
        public int ColumnNumber { get; set; }
        public bool Active { get; set; }
        public string ValidationMessage { get; set; }
        public string CssClass { get; set; }
        public int Behavior { get; set; }

        public virtual TicketType TicketType { get; set; }
        public virtual ICollection<TicketFormGroup> TicketFormGroup { get; set; }
    }
}
