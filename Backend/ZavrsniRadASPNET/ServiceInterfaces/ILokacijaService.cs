using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface ILokacijaService
    {
        List<Lokacija> GetLokacijaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Lokacija GetLokacija(int ID);
        int GetLokacijaCount();
        bool AddLokacija(Lokacija lokacija);
        bool UpdateLokacija(Lokacija lokacija);
        bool DeleteLokacija(int ID);
    }
}