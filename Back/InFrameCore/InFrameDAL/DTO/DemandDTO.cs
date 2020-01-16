using System;
using System.Collections.Generic;
using System.Text;

namespace InFrameDAL.DTO
{
    public class DemandDTO
    {

        public long Id { get; set; }
        public long WorkFlowId { get; set; }
        public long TypeId { get; set; }
        public long WorkflowStateId { get; set; }
        public string Author { get; set; }
        public DateTime CreateDate { get; set; }

        public Dictionary<string,object> dynPropValues { get; set; }

}
}
