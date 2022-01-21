using ClothesToU.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesToU.Site.Models.Core.Interfaces
{
    public interface IRegisterRepository
    {
        bool IsExist(string account);
        void Create(RegisterEntity entity);

    }
}
