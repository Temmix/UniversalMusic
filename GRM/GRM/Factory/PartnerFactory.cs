using GRM.Entity.Partner;
using GRM.Interface;

namespace GRM.Factory
{
    public class PartnerFactory : IPartnerFactory
    {
        public IPartner ProvidePartner(string name, string usage)
        {
            IPartner partner = null;
            switch (name.ToLower())
            {
                case "itunes":
                    partner = new ITunes(usage);
                    break;
                case "youtube":
                    partner = new YouTube(usage);
                    break;
                default:
                    break;
            }
            return partner;
        }
        
    }
}
