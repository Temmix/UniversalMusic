using GRM.Factory;
using GRM.Interface;
using GRM.Repository;
using Ninject.Modules;
using System;

namespace GRM.DI
{
    public class NinjectGRM : NinjectModule
    {
        public override void Load()
        {
            Bind<IPartnerRepository>().ToConstant(new PartnerRepository(new PartnerFactory())); ;
            Bind<IMusicRepository>().ToConstant(new MusicRepository(new MusicFactory()));
        }
    }
}
