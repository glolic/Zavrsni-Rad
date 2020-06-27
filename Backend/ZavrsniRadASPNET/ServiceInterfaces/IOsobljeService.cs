using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IOsobljeService
    {
        List<Osoblje> GetOsobljeCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Osoblje GetOsoblje(int ID);
        int GetOsobljeCount();
        bool AddOsoblje(Osoblje osoblje);
        bool UpdateOsoblje(Osoblje osoblje);
        bool DeleteOsoblje(int ID);
    }
}