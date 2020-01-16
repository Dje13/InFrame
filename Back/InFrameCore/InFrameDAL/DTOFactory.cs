using System;
using System.Collections.Generic;
using System.Text;
using InFrameDAL.Models;
using InFrameTools;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using InFrameFormManager.DTO;
using InFrameDAL.DTO;

namespace InFrameDAL
{
    public static class DTOFactory
    {

        public static DemandDTO getDemandConfigDTO(Demand myDemand)
        {
            DemandDTO result = new DemandDTO();
            ToolBox.MapObject(myDemand, result, true);

            result.dynPropValues = myDemand.getRealValues();
            return result;

        }

    }
}
