
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Favela.Library.Repository
{
    public interface IRepository<T>
    {
		#region GeneratedCode

		void Add(T obj);
		void Set(T obj);
		void Remove(T obj);
		void Get(T obj);
		List<T> GetAll();

		#endregion GeneratedCode
    }
}
