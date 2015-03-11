
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Grupo
    {
		#region GeneratedCode

		private static IGrupoRepository _Repository = null;

        public static IGrupoRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewGrupoRepository();
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

		public int? MatriculaMotorista 
		{ 
			get; 
			set; 
		}

		public int? MatriculaGuia 
		{ 
			get; 
			set; 
		}

		public string Obs 
		{ 
			get; 
			set; 
		}

		public int Status 
		{ 
			get; 
			set; 
		}

		public int? MatriculaFunc 
		{ 
			get; 
			set; 
		}

		public bool Invertido 
		{ 
			get; 
			set; 
		}

		public int Quantidade 
		{ 
			get; 
			set; 
		}

		public string Horario 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Grupo() : base() { }

		public Grupo(Grupo obj) : base() 
		{
			this.IdGrupo = obj.IdGrupo;
			this.MatriculaMotorista = obj.MatriculaMotorista;
			this.MatriculaGuia = obj.MatriculaGuia;
			this.Obs = obj.Obs;
			this.Status = obj.Status;
			this.MatriculaFunc = obj.MatriculaFunc;
			this.Invertido = obj.Invertido;
			this.Quantidade = obj.Quantidade;
			this.Horario = obj.Horario;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("idGrupo") && !Convert.IsDBNull(row["idGrupo"])) this.IdGrupo = Convert.ToInt32(row["idGrupo"]);
            if (row.Table.Columns.Contains("matriculaMotorista") && !Convert.IsDBNull(row["matriculaMotorista"])) this.MatriculaMotorista = Convert.ToInt32(row["matriculaMotorista"]);
            if (row.Table.Columns.Contains("matriculaGuia") && !Convert.IsDBNull(row["matriculaGuia"])) this.MatriculaGuia = Convert.ToInt32(row["matriculaGuia"]);
			if (row.Table.Columns.Contains("obs") && !Convert.IsDBNull(row["obs"])) this.Obs = Convert.ToString(row["obs"]);
			if (row.Table.Columns.Contains("status") && !Convert.IsDBNull(row["status"])) this.Status = Convert.ToInt32(row["status"]);
            if (row.Table.Columns.Contains("matriculaFunc") && !Convert.IsDBNull(row["matriculaFunc"])) this.MatriculaFunc = Convert.ToInt32(row["matriculaFunc"]);
			if (row.Table.Columns.Contains("invertido") && !Convert.IsDBNull(row["invertido"])) this.Invertido = Convert.ToBoolean(row["invertido"]);
			if (row.Table.Columns.Contains("quantidade") && !Convert.IsDBNull(row["quantidade"])) this.Quantidade = Convert.ToInt32(row["quantidade"]);
			if (row.Table.Columns.Contains("horario") && !Convert.IsDBNull(row["horario"])) this.Horario = Convert.ToString(row["horario"]);
        }

		public static List<Grupo> GetList(DataTable dt)
        {
            List<Grupo> lista = new List<Grupo>();

            Grupo obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Grupo();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
