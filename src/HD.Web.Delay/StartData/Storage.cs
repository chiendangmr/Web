using HD.TVAD.Entities.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HD.TVAD.Web.StartData
{
    public static class StorageExtentions
    {
        public static void Register(TVAdContext context)
        {
            var name = Dns.GetHostName();

            if(!context.Storage_Storages.Any(s=>s.Name == name))
            {
                context.Storage_Storages.Add(new Entities.Entities.Storage.Storage()
                {
                    Name = name,
                    Description = Dns.GetHostName()
                });
                context.SaveChanges();
            }
        }
    }
}
