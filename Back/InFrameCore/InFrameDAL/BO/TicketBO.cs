﻿using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
using InFrameFormManager;
using System.Linq;

namespace InFrameDAL.Models
{
    public partial class Ticket : ObjWithDynProp,IObjWithDynProp
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
            return this.TicketDynPropValue.ToDictionary(s => s.DynProp.DynPropName, s => (IObjDynPropValue)s, StringComparer.CurrentCultureIgnoreCase);
        }

    }
}
