using Practical1.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace Practical1.Data
{
    public class HistoryTableData : IHistoryTableData
    {
        public HistoryTable GetByKey(int id)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return (context.HistoryTables.Where(x => x.Id == id)).FirstOrDefault();
            }
        }

        public int Create(HistoryTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Added;
                context.SaveChanges();

                return data.Id;
            }
        }

        public int Update(HistoryTable data)
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                context.Entry(data).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();

                return data.Id;
            }
        }

        public List<HistoryTable> Search()
        {
            using (Practical1Entities context = new Practical1Entities())
            {
                return context.HistoryTables.ToList();
            }
        }
    }
}
