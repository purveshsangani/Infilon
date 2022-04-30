using Practical1.Data;
using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Manager
{
    public class HistoryTableManager : IHistoryTableManager
    {
        public readonly IHistoryTableData data = new HistoryTableData();

        public HistoryTable GetByKey(int id)
        {
            return data.GetByKey(id);
        }

        public int Save(HistoryTable data)
        {
            if (data.Id == 0)
            {
                return this.data.Create(data);
            }
            return this.data.Update(data);
        }

        public List<HistoryTable> Search()
        {
            return data.Search();
        }
    }
}
