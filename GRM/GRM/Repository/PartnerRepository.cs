using GRM.Factory;
using GRM.Interface;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GRM.Repository
{
    public class PartnerRepository : IPartnerRepository
    {
        private readonly IPartnerFactory factory;
        private const int propertyCount = 2;
        
        public PartnerRepository(IPartnerFactory _factory)
        {
            this.factory = _factory;
        }
        public IEnumerable<IPartner> GetAll()
        {
            var partnerList = new List<IPartner>();
            var fullPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var fullFileName = Path.Combine(fullPath, @"Files\PartnerContracts.txt");
            using (StreamReader reader = new StreamReader(fullFileName))
            {
                string line;
                while (( line = reader.ReadLine()) != null)
                {
                    var lineArr = line.Split('|');
                    if (lineArr.Length == propertyCount)
                    {
                        var partner = factory.ProvidePartner(lineArr[0], lineArr[1]);
                        if (partner != null)
                        {
                            partnerList.Add(partner);
                        }
                    }
                }
            } 
            return partnerList;
        }

        public IPartner Get(string name)
        { 
            return this.GetAll().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
