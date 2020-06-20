using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IKlubService
    {
        List<Klub> GetKlubCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Klub GetKlub(int ID);
        int GetKlubCount();
        bool AddKlub(Klub klub);
        bool UpdateKlub(Klub klub);
        bool DeleteKlub(int ID);
    }
}