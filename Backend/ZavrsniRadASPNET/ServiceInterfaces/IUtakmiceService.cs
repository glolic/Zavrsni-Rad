using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IUtakmiceService
    {
        List<Utakmice> GetUtakmiceCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Utakmice GetUtakmice(int ID);
        int GetUtakmiceCount();
        bool AddUtakmice(Utakmice utakmica);
        bool UpdateUtakmice(Utakmice utakmica);
        bool DeleteUtakmice(int ID);
    }
}