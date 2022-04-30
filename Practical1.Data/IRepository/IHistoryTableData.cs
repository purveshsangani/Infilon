using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Data
{
    public interface IHistoryTableData
    {
        int Create(HistoryTable data);
        HistoryTable GetByKey(int id);
        List<HistoryTable> Search();
        int Update(HistoryTable data);
    }
}