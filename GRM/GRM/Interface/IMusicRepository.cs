using GRM.Entity.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRM.Interface
{
    public interface IMusicRepository
    {
        IEnumerable<Music> GetAll();
        IEnumerable<Music> Get(string usage, DateTime date);
    }
}
