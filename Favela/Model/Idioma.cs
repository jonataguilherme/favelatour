
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Idioma
    {
		#region GeneratedCode

		private static IIdiomaRepository _Repository = null;

        public static IIdiomaRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewIdiomaRepository();
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

		public string Descricao 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Idioma() : base() { }

		public Idioma(Idioma obj) : base() 
		{
			this.Id = obj.Id;
			this.Descricao = obj.Descricao;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("id") && !Convert.IsDBNull(row["id"])) this.Id = Convert.ToInt32(row["id"]);
			if (row.Table.Columns.Contains("descricao") && !Convert.IsDBNull(row["descricao"])) this.Descricao = Convert.ToString(row["descricao"]);
        }

		public static List<Idioma> GetList(DataTable dt)
        {
            List<Idioma> lista = new List<Idioma>();

            Idioma obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Idioma();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
