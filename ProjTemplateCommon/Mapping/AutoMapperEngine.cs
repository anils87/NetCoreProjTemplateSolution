using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MappingEngine = AutoMapper;

namespace ProjTemplateCommon.Mapping
{
    public class AutoMapperEngine : IMappingEngine
    {
        private readonly IMapper _mapper;
        public AutoMapperEngine(MappingEngine.IMapper mappingEngine)
        {
            _mapper = mappingEngine;
        }

        public TTo MapTo<TTo>(object objFrom) where TTo : class, new()
        {
            return _mapper.Map<TTo>(objFrom);
        }

        public TTo MapTo<TFrom, TTo>(TFrom objFrom, TTo objTo) where TTo : class
        {
            return _mapper.Map(objFrom,objTo);
        }

        public IEnumerable<TTo> MapToList<TTo>(IEnumerable<object> objFromList, Action<object, TTo> postMapAction = null) where TTo : class, new()
        {
            var objToList = new List<TTo>();
            foreach(var objFrom in objFromList)
            {
                if (objFrom == null)
                    continue;
                var objTo = MapTo<TTo>(objFrom);

                if(objTo == null)
                    continue ;

                postMapAction?.Invoke(objFrom, objTo);
                objToList.Add(objTo);
            }
            return objToList;
        }
    }
}
