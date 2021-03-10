using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class Transition
    {
        public Transition()
        {
            TicketTransitionHisto = new HashSet<TicketTransitionHisto>();
            TransitionStartState = new HashSet<TransitionStartState>();
            WorkFlowTransition = new HashSet<WorkFlowTransition>();
        }

        public long Id { get; set; }
        public string TransitionName { get; set; }
        public string InternalName { get; set; }
        public string TransitionShortName { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public int Active { get; set; }
        public long EndStateId { get; set; }
        public string Actions { get; set; }
        public int? Behavior { get; set; }
        public int? AffichagePriority { get; set; }

        public virtual WorkflowState EndState { get; set; }
        public virtual ICollection<TicketTransitionHisto> TicketTransitionHisto { get; set; }
        public virtual ICollection<TransitionStartState> TransitionStartState { get; set; }
        public virtual ICollection<WorkFlowTransition> WorkFlowTransition { get; set; }
    }
}
