using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;

namespace ZavrsniRadASPNET.ServiceInterfaces
{
    public interface IPozicijaService
    {
        List<Pozicija> GetPozicijaCollection(int pageIndex, int pageSize, string sortColumn, string sortOrder);
        Pozicija GetPozicija(int ID);
        int GetPozicijaCount();
        bool AddPozicija(Pozicija pozicija);
        bool UpdatePozicija(Pozicija pozicija);
        bool DeletePozicija(int ID);
    }
}