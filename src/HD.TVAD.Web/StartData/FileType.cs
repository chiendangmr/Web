using HD.TVAD.Entities.Context;
using HD.TVAD.Entities.Entities.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HD.TVAD.Web.StartData
{
    public static class FileTypeEnumExtentions
    {
        public static void RegisterAll(TVAdContext context)
        {
            Dictionary<FileTypeEnum, string> fileTypes = new Dictionary<FileTypeEnum, string>();
            foreach (FileTypeEnum fileType in Enum.GetValues(typeof(FileTypeEnum)))
            {
                fileTypes.Add(fileType, fileType.GetDisplayName());
            }

            // Get all access in db
            var dbFileTypes = context.Storage_FileTypes.ToList();
            context.Storage_FileTypes.RemoveRange(dbFileTypes.Where(t => !fileTypes.ContainsKey((FileTypeEnum)t.Id)));
            context.SaveChanges();

            // Add or update access zone
            foreach (var fileType in fileTypes)
            {
                var old = context.Storage_FileTypes
                    .Where(t => t.Id == (int)fileType.Key)
                    .FirstOrDefault();

                if (old == null)
                {
                    context.Storage_FileTypes.Add(new FileType()
                    {
                        Id = (int)fileType.Key,
                        Name = fileType.Key.ToString(),
                        Description = fileType.Value
                    });
                }
                else if (old.Name != fileType.Key.ToString() || old.Description != fileType.Value)
                {
                    old.Name = fileType.Key.ToString();
                    old.Description = fileType.Value;
                }
            }
            context.SaveChanges();
        }
    }
}
