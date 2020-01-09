using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class WorkflowState
    {
        public WorkflowState()
        {
            Demand = new HashSet<Demand>();
            FormField = new HashSet<FormField>();
            Transition = new HashSet<Transition>();
            TransitionStartState = new HashSet<TransitionStartState>();
            WorkFlow = new HashSet<WorkFlow>();
        }

        public long Id { get; set; }
        public string StateName { get; set; }
        public string StateShortName { get; set; }
        public string StateDescription { get; set; }
        public string Icon { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Demand> Demand { get; set; }
        public virtual ICollection<FormField> FormField { get; set; }
        public virtual ICollection<Transition> Transition { get; set; }
        public virtual ICollection<TransitionStartState> TransitionStartState { get; set; }
        public virtual ICollection<WorkFlow> WorkFlow { get; set; }
    }
}
