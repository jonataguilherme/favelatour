
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Model;
using Favela.Library.Repository;

using Favela.Library.Repository.AdoMysql;
using System.Configuration;

namespace Favela.Library.Repository.AdoMysql
{
    [Serializable]
    class GruporeservaAdoMysqlRepository : IGruporeservaRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public GruporeservaAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Gruporeserva obj)
        {
            string commandText = @" INSERT INTO gruporeserva ( idGrupo, idReserva ) VALUES ( @idGrupo, @idReserva )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@idReserva", obj.IdReserva);

            command.ExecuteNonQuery();
            
        }

        public void Set(Gruporeserva obj)
        {
            string commandText = @" UPDATE gruporeserva SET idGrupo = @idGrupo, idReserva = @idReserva WHERE (idGrupo = @idGrupo) AND (idReserva = @idReserva) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@idReserva", obj.IdReserva);

            command.ExecuteNonQuery();
        }

        public void Remove(Gruporeserva obj)
        {
            string commandText = @" DELETE FROM gruporeserva WHERE (idGrupo = @idGrupo) AND (idReserva = @idReserva) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@idReserva", obj.IdReserva);

            command.ExecuteNonQuery();
        }

        public void Get(Gruporeserva obj)
        {
			string commandText = @" SELECT idGrupo, idReserva FROM gruporeserva WHERE (idGrupo = @idGrupo) AND (idReserva = @idReserva) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@idReserva", obj.IdReserva);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Gruporeserva> GetAll() 
		{
			string commandText = @" SELECT idGrupo, idReserva FROM gruporeserva ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Gruporeserva.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
