﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.BaseClasses
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple =false, Inherited = true)]
    public class InjectibleAttribute : Attribute
    {
    }
}
