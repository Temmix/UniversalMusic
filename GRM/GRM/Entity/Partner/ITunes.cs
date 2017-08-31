using GRM.Factory;
using GRM.Interface;

namespace GRM.Entity.Partner
{
    public class ITunes : IPartner
    {
        public string Name { get { return "ITunes"; } }
        public string Usage { get; private set; }

        public ITunes(string usage)
        {
            this.Usage = usage;
        }
    }
}
