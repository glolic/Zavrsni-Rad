using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class UlogaMapper
    {
        public UlogaView MapUlogaToBasicUloga(Uloga uloga)
        {
            var result = new UlogaView
            {
                Id = uloga.Id,
                Naziv = uloga.Naziv
            };
            return result;
        }

        public IEnumerable<UlogaView> MapUlogaCollectionToBasicUlogaCollection(IEnumerable<Uloga> ulogaCollection)
        {
            var result = new List<UlogaView>();
            foreach (Uloga uloga in ulogaCollection)
            {
                var basicUloga = this.MapUlogaToBasicUloga(uloga);
                result.Add(basicUloga);
            }

            return result;
        }

        public Uloga MapUlogaViewToUloga(UlogaView view)
        {
            var result = new Uloga()
            {
                Id = view.Id,
                Naziv = view.Naziv
            };
            return result;
        }
    }
}