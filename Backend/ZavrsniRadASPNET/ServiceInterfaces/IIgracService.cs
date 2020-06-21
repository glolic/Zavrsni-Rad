using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IIgracService
    {
        List<Igraci> GetIgracCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Igraci GetIgrac(int ID);
        int GetIgracCount();
        bool AddIgrac(Igraci igrac);
        bool UpdateIgrac(Igraci igrac);
        bool DeleteIgrac(int ID);
    }
}