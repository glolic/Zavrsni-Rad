using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadBackend.Models;

namespace ZavrsniRadBackend.SInterfaces
{
    public interface ISpolService
    {
        List<Spol> GetSpolCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Spol GetSpol(int ID);
        int GetSpolCount();
        bool AddSpol(Spol spol);
        bool UpdateSpol(Spol spol);
        bool DeleteSpol(int ID);
    }
}