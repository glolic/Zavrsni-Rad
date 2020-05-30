using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IPartneriService
    {
        List<Partneri> GetPartnerCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Partneri GetPartner(int ID);
        int GetPartnerCount();
        bool AddPartner(Partneri partner);
        bool UpdatePartner(Partneri partner);
        bool DeletePartner(int ID);
    }
}