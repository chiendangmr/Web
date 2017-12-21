using Microsoft.AspNetCore.DataProtection.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HD.TVAD.Infrastructure.DataProtections
{
    public class SqlServerDataProtectionKeyRepository : IXmlRepository
    {
        private DataProtectionContext DbContext { get; set; }
        public SqlServerDataProtectionKeyRepository(DataProtectionContext dbContext)
        {
            this.DbContext = dbContext;
        }

        public IReadOnlyCollection<XElement> GetAllElements()
        {
            return new ReadOnlyCollection<XElement>(DbContext.DataProtectionKeys.Select(k => XElement.Parse(k.XmlData)).ToList());
        }

        public void StoreElement(XElement element, string friendlyName)
        {
            var dbSet = DbContext.DataProtectionKeys;
            var entity = dbSet.SingleOrDefault(k => k.FriendlyName == friendlyName);
            if (null != entity)
            {
                entity.XmlData = element.ToString();
                dbSet.Update(entity);
            }
            else
            {
                dbSet.Add(new DataProtectionKey
                {
                    FriendlyName = friendlyName,
                    XmlData = element.ToString()
                });
            }

            DbContext.SaveChanges();
        }
    }
}
