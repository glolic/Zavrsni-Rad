using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadBackend.Views;
using ZavrsniRadBackend.Models;
namespace ZavrsniRadBackend.Mappers
{
    public class SpolMapper
    {
        public SpolView MapSpolToBasicSpol(Spol spol) 
        {
            var result = new SpolView
            {
                Id = spol.Id,
                Naziv = spol.Naziv
            };
            return result;
        }

        public IEnumerable<SpolView> MapSpolCollectionToBasicSpolCollection(IEnumerable<Spol> spolCollection) 
        {
            var result = new List<SpolView>();
            foreach (Spol spol in spolCollection)
            {
                var basicSpol = this.MapSpolToBasicSpol(spol);
                result.Add(basicSpol);
            }

            return result;
        }

        public Spol MapSpolViewToSpol(SpolView view) 
        {
            var result = new Spol()
            {
                Id = view.Id,
                Naziv = view.Naziv
            };
            return result;
        }
    }
}