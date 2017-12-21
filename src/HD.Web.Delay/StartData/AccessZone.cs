using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.StartData
{
    public static class AccessZoneEnumExtentions
    {
        public static void RegisterAll(TVAdContext context)
        {
            Dictionary<AccessZoneEnum, string> accessZones = new Dictionary<AccessZoneEnum, string>();
            foreach (AccessZoneEnum accessZone in Enum.GetValues(typeof(AccessZoneEnum)))
            {
                accessZones.Add(accessZone, accessZone.GetDisplayName());
            }

            // Get all access in db
            var dbAccessZones = context.Storage_AccessZones.ToList();
            context.Storage_AccessZones.RemoveRange(dbAccessZones.Where(t => !accessZones.ContainsKey((AccessZoneEnum)t.Id)));
            context.SaveChanges();

            // Add or update access zone
            foreach (var accessZone in accessZones)
            {
                var old = context.Storage_AccessZones
                    .Where(t => t.Id == (int)accessZone.Key)
                    .FirstOrDefault();

                if (old == null)
                {
                    context.Storage_AccessZones.Add(new AccessZone()
                    {
                        Id = (int)accessZone.Key,
                        Name = accessZone.Key.ToString(),
                        Description = accessZone.Value
                    });
                }
                else if (old.Name != accessZone.Key.ToString() || old.Description != accessZone.Value)
                {
                    old.Name = accessZone.Key.ToString();
                    old.Description = accessZone.Value;
                }
            }
            context.SaveChanges();
        }
    }
}
