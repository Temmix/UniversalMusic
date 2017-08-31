using System;

namespace GRM.Interface
{
    public interface IPartnerFactory
    {
        IPartner ProvidePartner(string name, string usage);
    }
}
