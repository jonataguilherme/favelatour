
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Funcionario
    {
		#region GeneratedCode

		private static IFuncionarioRepository _Repository = null;

        public static IFuncionarioRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewFuncionarioRepository();
                }

                return _Repository;
            }
        }

		#region Properties
	   
		public int? Matricula 
		{ 
			get; 
			set; 
		}

		public string Nome 
		{ 
			get; 
			set; 
		}

		public string Telefone 
		{ 
			get; 
			set; 
		}

		public string Email 
		{ 
			get; 
			set; 
		}

		public int IdPapel 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Funcionario() : base() { }

		public Funcionario(Funcionario obj) : base() 
		{
			this.Matricula = obj.Matricula;
			this.Nome = obj.Nome;
			this.Telefone = obj.Telefone;
			this.Email = obj.Email;
			this.IdPapel = obj.IdPapel;
		}

		public void Load(DataRow row)
        {
            if (row.Table.Columns.Contains("matricula") && !Convert.IsDBNull(row["matricula"])) this.Matricula = Convert.ToInt32(row["matricula"]);
			if (row.Table.Columns.Contains("nome") && !Convert.IsDBNull(row["nome"])) this.Nome = Convert.ToString(row["nome"]);
			if (row.Table.Columns.Contains("telefone") && !Convert.IsDBNull(row["telefone"])) this.Telefone = Convert.ToString(row["telefone"]);
			if (row.Table.Columns.Contains("email") && !Convert.IsDBNull(row["email"])) this.Email = Convert.ToString(row["email"]);
			if (row.Table.Columns.Contains("idPapel") && !Convert.IsDBNull(row["idPapel"])) this.IdPapel = Convert.ToInt32(row["idPapel"]);
        }

		public static List<Funcionario> GetList(DataTable dt)
        {
            List<Funcionario> lista = new List<Funcionario>();

            Funcionario obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Funcionario();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
