using System;
using System.Collections.Generic;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
using InFrameFormManager;
using System.Linq;
using InFrameInterfaces.Ticket;

namespace InFrameDAL.Models
{
    public partial class Ticket : ITicket
    {
        //public override IObjType getType()
        //{
        //    return null;
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <returns></returns>
        //public override Dictionary<string, IObjDynPropValue> getValues()
        //{
        //    return TicketDynPropValue.ToDictionary(s => s.DynProp.DynPropName, s => (IObjDynPropValue)s, StringComparer.CurrentCultureIgnoreCase);
        //}
    }
}
