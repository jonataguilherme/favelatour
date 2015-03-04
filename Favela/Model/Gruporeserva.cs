
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Gruporeserva
    {
		#region GeneratedCode

		private static IGruporeservaRepository _Repository = null;

        public static IGruporeservaRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewGruporeservaRepository();
                }

                return _Repository;
            }
        }

		#region Properties
	   
		public int? IdGrupo 
		{ 
			get; 
			set; 
		}

		public int? IdReserva 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Gruporeserva() : base() { }

		public Gruporeserva(Gruporeserva obj) : base() 
		{
			this.IdGrupo = obj.IdGrupo;
			this.IdReserva = obj.IdReserva;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("idGrupo") && !Convert.IsDBNull(row["idGrupo"])) this.IdGrupo = Convert.ToInt32(row["idGrupo"]);
			if (row.Table.Columns.Contains("idReserva") && !Convert.IsDBNull(row["idReserva"])) this.IdReserva = Convert.ToInt32(row["idReserva"]);
        }

		public static List<Gruporeserva> GetList(DataTable dt)
        {
            List<Gruporeserva> lista = new List<Gruporeserva>();

            Gruporeserva obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Gruporeserva();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
