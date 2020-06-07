using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface INatjecanjaService
    {
        List<Natjecanja> GetNatjecanjaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Natjecanja GetNatjecanja(int ID);
        int GetNatjecanjaCount();
        bool AddNatjecanja(Natjecanja natjecanja);
        bool UpdateNatjecanja(Natjecanja natjecanja);
        bool DeleteNatjecanja(int ID);
    }
}