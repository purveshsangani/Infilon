using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Data
{
    public interface IOddTableData
    {
        int Create(OddTable data);
        OddTable GetByKey(int id);
        List<OddTable> Search();
        int Update(OddTable data);
        bool Remove(OddTable data);
        bool SaveAllData(List<OddTable> data);
    }
}