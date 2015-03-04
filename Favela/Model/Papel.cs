
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Papel
    {
		#region GeneratedCode

		private static IPapelRepository _Repository = null;

        public static IPapelRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewPapelRepository();
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

		public Papel() : base() { }

		public Papel(Papel obj) : base() 
		{
			this.Id = obj.Id;
			this.Descricao = obj.Descricao;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("id") && !Convert.IsDBNull(row["id"])) this.Id = Convert.ToInt32(row["id"]);
			if (row.Table.Columns.Contains("descricao") && !Convert.IsDBNull(row["descricao"])) this.Descricao = Convert.ToString(row["descricao"]);
        }

		public static List<Papel> GetList(DataTable dt)
        {
            List<Papel> lista = new List<Papel>();

            Papel obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Papel();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
