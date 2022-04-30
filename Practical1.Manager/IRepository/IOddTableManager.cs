using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Manager
{
    public interface IOddTableManager
    {
        OddTable GetByKey(int id);
        int Save(OddTable data);
        bool Remove(OddTable data);
        List<OddTable> Search();
        bool SaveAll(List<OddTable> data);
    }
}