using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chat.Api.Helpers.AutoMapper
{
    public static class MappingExtensions
    {
        public static TOut ToModel<TIn, TOut>(this TIn model)
            where TIn : class
            where TOut : class
        {
            return (model != null) ? Mapper.Map<TIn, TOut>(model) : default(TOut);
        }

        public static List<TOut> ToModel<TIn, TOut>(this List<TIn> modelList)
            where TIn : class
            where TOut : class
        {
            return (modelList != null) ? Mapper.Map<List<TOut>>(modelList) : default(List<TOut>);
        }
    }
}