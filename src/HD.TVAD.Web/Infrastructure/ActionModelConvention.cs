using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.Station.Infrastructure.Conventions
{
    public class AsyncActionConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            if (action.ActionName.EndsWith("Async"))
            {
                action.ActionName = action.ActionName.Substring(0, action.ActionName.Length - 5);
            }
        }
    }
}