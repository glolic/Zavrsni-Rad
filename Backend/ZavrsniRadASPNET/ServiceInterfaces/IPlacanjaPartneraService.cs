using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IPlacanjaPartneraService
    {
        List<PlacanjaPartneri> GetPlacanjaPartneraCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        PlacanjaPartneri GetPlacanjaPartner(int ID);
        int GetPlacanjaPartneriCount();
        bool AddPlacanjaPartner(PlacanjaPartneri spol);
        bool UpdatePlacanjaPartnera(PlacanjaPartneri spol);
        bool DeletePlacanjaPartner(int ID);
    }
}