using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Interface
{
    public interface IPartnerRepository
    {
        IEnumerable<IPartner> GetAll();
        IPartner Get(string name);
    }
}
