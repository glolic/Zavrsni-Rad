using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IUlogeService
    {
        List<Uloga> GetUlogaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Uloga GetUloga(int ID);
        int GetUlogaCount();
        bool AddUloga(Uloga spol);
        bool UpdateUloga(Uloga spol);
        bool DeleteUloga(int ID);
    }
}