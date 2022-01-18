using ClothesToU.BackEnd.Site.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesToU.BackEnd.Site.Models.Interfaces
{
	public interface IProdRepository
	{
		void Create(ProdEntity entity);
		void Update(ProdEntity entity);
		void Delete(int docId);
		IEnumerable<ProdEntity> Search(string title, string description);
		ProdEntity Load(int docId);
	}
}
