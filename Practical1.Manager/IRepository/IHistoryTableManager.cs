using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Manager
{
    public interface IHistoryTableManager
    {
        HistoryTable GetByKey(int id);
        int Save(HistoryTable data);
        List<HistoryTable> Search();
    }
}