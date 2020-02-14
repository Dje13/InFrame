using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class WorkFlow
    {
        public WorkFlow()
        {
            Demand = new HashSet<Demand>();
            DemandType = new HashSet<DemandType>();
            TicketType = new HashSet<TicketType>();
            WorkFlowTransition = new HashSet<WorkFlowTransition>();
        }

        public long Id { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowShortName { get; set; }
        public string WorkflowDescription { get; set; }
        public long StartStateId { get; set; }

        public virtual WorkflowState StartState { get; set; }
        public virtual ICollection<Demand> Demand { get; set; }
        public virtual ICollection<DemandType> DemandType { get; set; }
        public virtual ICollection<TicketType> TicketType { get; set; }
        public virtual ICollection<WorkFlowTransition> WorkFlowTransition { get; set; }
    }
}
