using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InFrameInterfaces.ObjWithDynProp;
using Newtonsoft.Json;

namespace InFrameFormManager
{
    public abstract class ObjWithDynProp : IObjWithDynProp
    {
        public long Id { get; set; }
       

        public abstract IObjType getType();
        public abstract Dictionary<string, IObjDynPropValue> getValues();

        protected Dictionary<string, IObjDynPropValue> _dynPropValues = null;

        public object this[string propName]
        {
            get
            {
                this.loadValues();
                if (this._dynPropValues.ContainsKey(propName))
                {
                    return getRealValue(this._dynPropValues[propName]);
                }
                else
                {
                    return null;
                }
            }
        }

        public Dictionary<string, object> getRealValues()
        {
            this.loadValues();

            return this._dynPropValues.ToDictionary(e => e.Key, e => getRealValue(e.Value));
        }
        protected void loadValues()
        {
            if (this._dynPropValues == null)
            {
                this._dynPropValues = this.getValues();
            }
        }
        protected object getRealValue(IObjDynPropValue curValue)
        {
            switch (curValue.getValueType().ToLower())
            {
                case "string":
                    return curValue.ValueString;
                case "listobject":
                    if (curValue.ValueString == null)
                    {
                        return null;
                    }
                    return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(curValue.ValueString);
                case "date":
                    return curValue.ValueDate;
                //return ((DateTime)curValue.ValueDate).ToString("dd/MM/yyyy hh:mm:ss");
                case "decimal":
                    return curValue.ValueDecimal;
                case "int":
                    return curValue.ValueInt;
                case "real":
                    return curValue.ValueReal;
                case "geom":
                    return curValue.ValueGeom;
                default:
                    return curValue.ValueString;
            }
        }
    }


}

