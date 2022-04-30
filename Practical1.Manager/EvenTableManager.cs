using Practical1.Data;
using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Manager
{
    public class EvenTableManager : IEvenTableManager
    {
        public readonly IEvenTableData data = new EvenTableData();
        public readonly IHistoryTableData dataHistory = new HistoryTableData();
        public EvenTable GetByKey(int id)
        {
            return data.GetByKey(id);
        }

        public int Save(EvenTable data)
        {
            if (data.Id == 0)
            {
                AddHistory(data, "Add");
                return this.data.Create(data);
            }
            AddHistory(data, "Update");
            return this.data.Update(data);
        }

        public bool Remove(EvenTable data)
        {
            AddHistory(data, "Remove");
            return this.data.Remove(data);
        }

        public bool SaveAll(List<EvenTable> data)
        {
            return this.data.SaveAllData(data);
        }

        public List<EvenTable> Search()
        {
            return data.Search();
        }
        public int AddHistory(EvenTable data, string Action)
        {
            HistoryTable historyTable = new HistoryTable()
            {
                Title = data.Title,
                Completed = data.Completed,
                ReferenceId = data.Id,
                UserId = data.UserId,
                Action = Action
            };
            return dataHistory.Create(historyTable);
        }
    }
}
