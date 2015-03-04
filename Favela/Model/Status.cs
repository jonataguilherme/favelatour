
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Status
    {
		#region GeneratedCode

		private static IStatusRepository _Repository = null;

        public static IStatusRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewStatusRepository();
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

		public Status() : base() { }

		public Status(Status obj) : base() 
		{
			this.Id = obj.Id;
			this.Nome = obj.Nome;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("id") && !Convert.IsDBNull(row["id"])) this.Id = Convert.ToInt32(row["id"]);
			if (row.Table.Columns.Contains("nome") && !Convert.IsDBNull(row["nome"])) this.Nome = Convert.ToString(row["nome"]);
        }

		public static List<Status> GetList(DataTable dt)
        {
            List<Status> lista = new List<Status>();

            Status obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Status();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
