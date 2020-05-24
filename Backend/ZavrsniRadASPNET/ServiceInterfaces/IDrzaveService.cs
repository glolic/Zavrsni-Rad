using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IDrzaveService
    {
        List<Drzave> GetDrzavaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Drzave GetDrzava(int ID);
        int GetDrzavaCount();
        bool AddDrzava(Drzave drzava);
        bool UpdateDrzava(Drzave drzava);
        bool DeleteDrzava(int ID);
    }
}