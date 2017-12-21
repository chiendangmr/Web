using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.StartData
{
    public static class UriTypeEnumExtentions
    {
        public static void RegisterAll(TVAdContext context)
        {
            Dictionary<UriTypeEnum, string> uriTypes = new Dictionary<UriTypeEnum, string>();
            foreach (UriTypeEnum uriType in Enum.GetValues(typeof(UriTypeEnum)))
            {
                uriTypes.Add(uriType, uriType.GetDisplayName());
            }

            // Get all access in db
            var dbUriTypes = context.Storage_UriTypes.ToList();
            context.Storage_UriTypes.RemoveRange(dbUriTypes.Where(t => !uriTypes.ContainsKey((UriTypeEnum)t.Id)));
            context.SaveChanges();

            // Add or update access zone
            foreach (var uriType in uriTypes)
            {
                var old = context.Storage_UriTypes
                    .Where(t => t.Id == (int)uriType.Key)
                    .FirstOrDefault();

                if (old == null)
                {
                    context.Storage_UriTypes.Add(new UriType()
                    {
                        Id = (int)uriType.Key,
                        Name = uriType.Key.ToString(),
                        Description = uriType.Value
                    });
                }
                else if (old.Name != uriType.Key.ToString() || old.Description != uriType.Value)
                {
                    old.Name = uriType.Key.ToString();
                    old.Description = uriType.Value;
                }
            }
            context.SaveChanges();
        }
    }
}
