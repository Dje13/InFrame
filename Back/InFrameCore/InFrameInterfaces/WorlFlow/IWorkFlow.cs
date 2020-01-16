using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameInterfaces.WorlFlow
{
    public interface IWorkFlow
    {
        public long Id { get; set; }
        public string WorkflowName { get; set; }
        public string WorkflowShortName { get; set; }
        public string WorkflowDescription { get; set; }

    }
}
