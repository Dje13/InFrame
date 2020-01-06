using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class TransitionStartState
    {
        public long Id { get; set; }
        public long TransitionId { get; set; }
        public long StartStateId { get; set; }

        public virtual WorkflowState StartState { get; set; }
        public virtual Transition Transition { get; set; }
    }
}
