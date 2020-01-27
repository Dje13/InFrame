using System;
using System.Collections.Generic;
using System.Linq;
using InFrameDAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                    .Where(s => s.Active).FirstOrDefault();
            }
            return Result;
        }

        public static List<FormConfig> getFormConfigList()
        {
            List<FormConfig> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Where(s => s.Active).ToList();
            }
            return Result;
        }

        public static List<string> getFormTypes()
        {
            List<string> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.FormConfig.Where(s => s.Active).Select(y => y.FormNature).Distinct().ToList();//.Select(x => new SelectListItem { Value = x.FormNature, Text = x.FormNature});
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

        #region "Ticket Management"

        public static List<Ticket> getTicketList()
        {

            List<Ticket> Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.Ticket.ToList();
            }
            return Result;
        }

        public static Ticket getTicket(int id)
        {

            Ticket Result;
            using (InFrameContext db = new InFrameContext())
            {
                Result = db.Ticket.Where(x => x.Id == id).FirstOrDefault();
            }
            return Result;
        }

        #endregion


    }
}
