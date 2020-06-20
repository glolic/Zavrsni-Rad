using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IMomcadService
    {
        List<Momcadi> GetMomcadCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Momcadi GetMomcad(int ID);
        int GetMomcadCount();
        bool AddMomcad(Momcadi momcad);
        bool UpdateMomcad(Momcadi momcad);
        bool DeleteMomcad(int ID);
    }
}