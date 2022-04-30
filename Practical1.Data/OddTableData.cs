using Practical1.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Practical1.Data
{
    public class OddTableData : IOddTableData
    {
        public OddTable GetByKey(int id)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return (context.OddTables.Where(x => x.Id == id)).FirstOrDefault();
            }
        }

        public int Create(OddTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return data.Id;
            }
        }

        public int Update(OddTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return data.Id;
            }
        }

        public bool Remove(OddTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
        }

        public bool SaveAllData(List<OddTable> data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.OddTables.AddRange(data);
                context.SaveChanges();
            }
            return true;
        }

        public List<OddTable> Search()
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return context.OddTables.ToList();
            }
        }
    }
}
