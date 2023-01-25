using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProjTemplateCommon.Mapping
{
    public interface IMappingEngine
    {
        TTo MapTo<TTo>(object objFrom) where TTo : class ,new();
        TTo MapTo<TFrom, TTo>(TFrom objFrom , TTo objTo) where TTo : class;
        IEnumerable<TTo> MapToList<TTo>(IEnumerable<object> objFromList, Action<object, TTo> postMapAction = null) where TTo : class, new();
    }
}
