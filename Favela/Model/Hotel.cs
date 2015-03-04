
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Hotel
    {
		#region GeneratedCode

		private static IHotelRepository _Repository = null;

        public static IHotelRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewHotelRepository();
                }

                return _Repository;
            }
        }

		#region Properties
	   
		public int? Id 
		{ 
			get; 
			set; 
		}

		public string Nome 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Hotel() : base() { }

		public Hotel(Hotel obj) : base() 
		{
			this.Id = obj.Id;
			this.Nome = obj.Nome;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("id") && !Convert.IsDBNull(row["id"])) this.Id = Convert.ToInt32(row["id"]);
			if (row.Table.Columns.Contains("nome") && !Convert.IsDBNull(row["nome"])) this.Nome = Convert.ToString(row["nome"]);
        }

		public static List<Hotel> GetList(DataTable dt)
        {
            List<Hotel> lista = new List<Hotel>();

            Hotel obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Hotel();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
