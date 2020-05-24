using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class DrzaveMapper
    {
        public DrzaveView MapDrzaveToBasicDrzave(Drzave drzave)
        {
            var result = new DrzaveView
            {
                Id = drzave.Id,
                NazivDrzave = drzave.NazivDrzave,
                Oznaka = drzave.Oznaka
            };

            return result;
        }

        public IEnumerable<DrzaveView> MapDrzaveCollectionToBasicDrzaveCollection(IEnumerable<Drzave> drzaveCollection)
        {
            var result = new List<DrzaveView>();
            foreach (Drzave drzave in drzaveCollection)
            {
                var basicDrzave = this.MapDrzaveToBasicDrzave(drzave);
                result.Add(basicDrzave);
            }

            return result;
        }

        public Drzave MapDrzaveViewToDrzave(DrzaveView view)
        {
            var result = new Drzave()
            {
                Id = view.Id,
                NazivDrzave = view.NazivDrzave,
                Oznaka = view.Oznaka
            };

            return result;
        }
    }
}