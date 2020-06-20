using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IOsobaService
    {
        List<Osoba> GetOsobaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Osoba GetOsoba(int ID);
        int GetOsobaCount();
        bool AddOsoba(Osoba osoba);
        bool UpdateOsoba(Osoba osoba);
        bool DeleteOsoba(int ID);
    }
}