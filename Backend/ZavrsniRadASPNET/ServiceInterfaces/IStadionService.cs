using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IStadionService
    {
        List<Stadioni> GetStadionCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Stadioni GetStadion(int ID);
        int GetStadionCount();
        bool AddStadion(Stadioni stadion);
        bool UpdateStadion(Stadioni stadion);
        bool DeleteStadion(int ID);
    }
}