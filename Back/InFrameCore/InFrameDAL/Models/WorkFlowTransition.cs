using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class WorkFlowTransition
    {
        public long Id { get; set; }
        public long WorkflowId { get; set; }
        public long TransitionId { get; set; }
        public int Active { get; set; }

        public virtual Transition Transition { get; set; }
        public virtual WorkFlow Workflow { get; set; }
    }
}
