using GRM.Entity.Partner;
using GRM.Interface;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace GRM.TEST.FakeRepository
{
    public class FakePartnerRepository : IPartnerRepository
    {
        public IEnumerable<IPartner> GetAll()
        {
            return this.ProvidePartners();
        }

        public IPartner Get(string name)
        {
            return this.ProvidePartners().Where(x => x.Name == name).FirstOrDefault();
        }

        private  IEnumerable<IPartner> ProvidePartners()
        {
            return new List<IPartner> { new YouTube("streaming"), new ITunes("digital download") };
        }
    }
}
