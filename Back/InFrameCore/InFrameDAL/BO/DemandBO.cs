using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
using InFrameFormManager;
using System.Linq;

namespace InFrameDAL.Models
{
    public partial class Demand: ObjWithDynProp,IObjWithDynProp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IObjType getType()
        {
            return this.Type;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Dictionary<string, IObjDynPropValue> getValues()
        {
            return this.DemandDynPropValue.ToDictionary(s=>s.DynProp.DynPropName,s=>(IObjDynPropValue)s,StringComparer.CurrentCultureIgnoreCase);
        }


    }
}
