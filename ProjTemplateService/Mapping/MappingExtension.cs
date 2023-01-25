using System.Linq.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjTemplateCommon.Enums;

namespace ProjTemplateService.Mapping
{
    public static class MappingExtension
    {
        
        public static Type GetClrType(this DataTypes dataType)
        {
            switch (dataType)
            {
                case DataTypes.Boolean:
                    return typeof(bool);
                case DataTypes.Numeric:
                    return typeof(decimal);
                case DataTypes.String:
                    return typeof(string);
                case DataTypes.DateTime:
                    return typeof(DateTime);
                default:
                    return typeof(object);
            }
        }
    }
}
