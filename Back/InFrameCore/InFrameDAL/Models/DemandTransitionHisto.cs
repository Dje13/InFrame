using System;
using System.Collections.Generic;

namespace InFrameDAL.Models
{
    public partial class DemandTransitionHisto
    {
        public long Id { get; set; }
        public long DemandId { get; set; }
        public long TransitionId { get; set; }
        public DateTime TransitionDate { get; set; }
        public string Comment { get; set; }

        public virtual Demand Demand { get; set; }
        public virtual Transition Transition { get; set; }
    }
}
