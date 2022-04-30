using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Data
{
    public interface IEvenTableData
    {
        int Create(EvenTable data);
        EvenTable GetByKey(int id);
        List<EvenTable> Search();
        int Update(EvenTable data);
        bool Remove(EvenTable data);
        bool SaveAllData(List<EvenTable> data);
    }
}