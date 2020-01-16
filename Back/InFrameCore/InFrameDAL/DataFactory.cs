using System;
using System.Linq;
using InFrameDAL.Models;
using Microsoft.EntityFrameworkCore;

namespace InFrameDAL
{
    public static class DataFactory
    {

        #region "Form Management"
        public static FormConfig getFormConfigById(long id)
        {
            FormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Include("FormGroup").Include("FormGroup.FormField")
                    .Where(s => s.Id == id && s.Active).FirstOrDefault();
            }
            return Result;
        }

        public static FormConfig getFormConfigByDemandType(long id)
        {
            FormConfig Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Include("FormGroup").Include("FormGroup.FormField")
                    .Where(s => s.TypeId == id && s.Active).FirstOrDefault();
            }
            return Result;
        }

        #endregion

        #region "Demand Management"

        public static Demand getDemandById(long id)
        {

            Demand Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.Demand.Include("DemandDynPropValue").Include("DemandDynPropValue.DynProp").Include("Type").Include("WorkflowState")
                    .Where(d => d.Id == id ).FirstOrDefault();
            }
            return Result;
        }

        #endregion


    }
}
