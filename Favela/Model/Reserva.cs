
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Repository;

namespace Favela.Library.Model
{
    [Serializable]
    public partial class Reserva
    {
		#region GeneratedCode

		private static IReservaRepository _Repository = null;

        public static IReservaRepository Repository
        {
            get
            {
                if (_Repository == null)
                {
                    RepositoryFactory factory = RepositoryFactory.Default();

                    _Repository = factory.NewReservaRepository();
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

		public DateTime DataHora 
		{ 
			get; 
			set; 
		}

		public int IdTurno 
		{ 
			get; 
			set; 
		}

		public int IdIdioma 
		{ 
			get; 
			set; 
		}

		public bool Privativo 
		{ 
			get; 
			set; 
		}

		public string NomeCliente 
		{ 
			get; 
			set; 
		}

		public string Email 
		{ 
			get; 
			set; 
		}

		public int Quantidade 
		{ 
			get; 
			set; 
		}

		public bool NoHotel 
		{ 
			get; 
			set; 
		}

		public int IdHotel 
		{ 
			get; 
			set; 
		}

		public string Apartamento 
		{ 
			get; 
			set; 
		}

		public string OrigemPrecoContato 
		{ 
			get; 
			set; 
		}

		public string Pais 
		{ 
			get; 
			set; 
		}


		#endregion Properties

		#region Construtors

		public Reserva() : base() { }

		public Reserva(Reserva obj) : base() 
		{
			this.Id = obj.Id;
			this.DataHora = obj.DataHora;
			this.IdTurno = obj.IdTurno;
			this.IdIdioma = obj.IdIdioma;
			this.Privativo = obj.Privativo;
			this.NomeCliente = obj.NomeCliente;
			this.Email = obj.Email;
			this.Quantidade = obj.Quantidade;
			this.NoHotel = obj.NoHotel;
			this.IdHotel = obj.IdHotel;
			this.Apartamento = obj.Apartamento;
			this.OrigemPrecoContato = obj.OrigemPrecoContato;
			this.Pais = obj.Pais;
		}

		public void Load(DataRow row)
        {
			if (row.Table.Columns.Contains("id") && !Convert.IsDBNull(row["id"])) this.Id = Convert.ToInt32(row["id"]);
			if (row.Table.Columns.Contains("dataHora") && !Convert.IsDBNull(row["dataHora"])) this.DataHora = Convert.ToDateTime(row["dataHora"]);
			if (row.Table.Columns.Contains("idTurno") && !Convert.IsDBNull(row["idTurno"])) this.IdTurno = Convert.ToInt32(row["idTurno"]);
			if (row.Table.Columns.Contains("idIdioma") && !Convert.IsDBNull(row["idIdioma"])) this.IdIdioma = Convert.ToInt32(row["idIdioma"]);
			if (row.Table.Columns.Contains("privativo") && !Convert.IsDBNull(row["privativo"])) this.Privativo = Convert.ToBoolean(row["privativo"]);
			if (row.Table.Columns.Contains("nomeCliente") && !Convert.IsDBNull(row["nomeCliente"])) this.NomeCliente = Convert.ToString(row["nomeCliente"]);
			if (row.Table.Columns.Contains("email") && !Convert.IsDBNull(row["email"])) this.Email = Convert.ToString(row["email"]);
			if (row.Table.Columns.Contains("quantidade") && !Convert.IsDBNull(row["quantidade"])) this.Quantidade = Convert.ToInt32(row["quantidade"]);
			if (row.Table.Columns.Contains("noHotel") && !Convert.IsDBNull(row["noHotel"])) this.NoHotel = Convert.ToBoolean(row["noHotel"]);
			if (row.Table.Columns.Contains("idHotel") && !Convert.IsDBNull(row["idHotel"])) this.IdHotel = Convert.ToInt32(row["idHotel"]);
			if (row.Table.Columns.Contains("apartamento") && !Convert.IsDBNull(row["apartamento"])) this.Apartamento = Convert.ToString(row["apartamento"]);
			if (row.Table.Columns.Contains("origemPrecoContato") && !Convert.IsDBNull(row["origemPrecoContato"])) this.OrigemPrecoContato = Convert.ToString(row["origemPrecoContato"]);
			if (row.Table.Columns.Contains("pais") && !Convert.IsDBNull(row["pais"])) this.Pais = Convert.ToString(row["pais"]);
        }

		public static List<Reserva> GetList(DataTable dt)
        {
            List<Reserva> lista = new List<Reserva>();

            Reserva obj = null;

            foreach (DataRow row in dt.Rows)
            {
                obj = new Reserva();
                obj.Load(row);

                lista.Add(obj);
            }

            return lista;
        }

		#endregion Construtors

		#endregion GeneratedCode
    }
}
