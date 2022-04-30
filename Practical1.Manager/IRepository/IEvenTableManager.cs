using Practical1.Model.Model;
using System.Collections.Generic;

namespace Practical1.Manager
{
    public interface IEvenTableManager
    {
        EvenTable GetByKey(int id);
        int Save(EvenTable data);
        bool Remove(EvenTable data);
        List<EvenTable> Search();
        bool SaveAll(List<EvenTable> data);
    }
}