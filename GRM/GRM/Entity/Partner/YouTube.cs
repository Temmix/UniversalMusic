using GRM.Factory;
using GRM.Interface;

namespace GRM.Entity.Partner
{
    public class YouTube : IPartner
    {
        public string  Name { get { return "YouTube"; } }

        public string Usage { get; private set; }

        public YouTube(string usage)
        {
            this.Usage = usage;
        }
    }
}
