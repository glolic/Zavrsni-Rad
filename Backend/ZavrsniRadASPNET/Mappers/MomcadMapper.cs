using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZavrsniRadASPNET.Models;
using ZavrsniRadASPNET.Views;

namespace ZavrsniRadASPNET.Mappers
{
    public class MomcadMapper
    {
        public MomcadView MapMomcadToBasicMomcad(Momcadi momcad)
        {
            var result = new MomcadView
            {
                Id = momcad.Id,
                Naziv = momcad.Naziv,
                Klub = new KlubView()
                {
                    Id = momcad.Klub.Id,
                    Naziv = momcad.Klub.Naziv
                }
            };
            return result;
        }

        public IEnumerable<MomcadView> MapMomcadCollectionToBasicMomcadCollection(IEnumerable<Momcadi> momcadCollection)
        {
            var result = new List<MomcadView>();
            foreach (Momcadi momcad in momcadCollection)
            {
                var basicMomcad = this.MapMomcadToBasicMomcad(momcad);
                result.Add(basicMomcad);
            }

            return result;
        }

        public Momcadi MapMomcadViewToMomcad(MomcadView view)
        {
            var result = new Momcadi()
            {
                Id = view.Id,
                Naziv = view.Naziv,
                KlubId = view.Klub.Id
            };
            return result;
        }
    }
}