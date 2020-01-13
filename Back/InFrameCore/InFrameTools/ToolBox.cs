using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Reflection;

namespace InFrameTools
{
    public class ToolBox
    {

        /// <summary>
        /// Map object with relexion
        /// </summary>
        /// <param name="SourceObject"></param>
        /// <param name="TargetObject"></param>
        /// <param name="WithId">True :  ID is mapped otherwise ID field is ignored</param>
        public static void MapObject(object SourceObject, object TargetObject, bool WithId = false, List<string> unMappedField = null)
        {
            if (unMappedField == null)
            {
                unMappedField = new List<string>();
            }
            PropertyInfo[] SourceProps = SourceObject.GetType().GetProperties();
            PropertyInfo[] TargetProps = TargetObject.GetType().GetProperties();

            for (int i = 0; i < SourceProps.Length; i++)
            {
                PropertyInfo DTOProp = TargetProps.Where(s => s.Name.ToLower() == SourceProps[i].Name.ToLower()).FirstOrDefault();

                if (unMappedField.Where(s=>s.ToLower() == SourceProps[i].Name.ToLower()).FirstOrDefault() == null && SourceProps[i].PropertyType.Namespace == "System" && (DTOProp != null) && DTOProp.CanWrite && (SourceProps[i].Name.ToLower() != "id" || WithId))
                {
                    DTOProp.SetValue(TargetObject, SourceProps[i].GetValue(SourceObject, null));
                }
            }
        }
    }
}
