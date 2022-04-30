using Practical1.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Practical1.Data
{
    public class EvenTableData : IEvenTableData
    {
        public EvenTable GetByKey(int id)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return (context.EvenTables.Where(x => x.Id == id)).FirstOrDefault();
            }
        }

        public int Create(EvenTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return data.Id;
            }
        }

        public int Update(EvenTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return data.Id;
            }
        }

        public bool Remove(EvenTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                context.SaveChanges();

                return true;
            }
        }

        public bool SaveAllData(List<EvenTable> data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.EvenTables.AddRange(data);
                context.SaveChanges();
            }
            return true;
        }

        public List<EvenTable> Search()
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return context.EvenTables.ToList();
            }
        }
    }
}
