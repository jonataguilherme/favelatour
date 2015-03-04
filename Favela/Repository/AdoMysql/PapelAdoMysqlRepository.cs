
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
    class PapelAdoMysqlRepository : IPapelRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public PapelAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Papel obj)
        {
            string commandText = @" INSERT INTO papel ( descricao ) VALUES ( @descricao )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@descricao", obj.Descricao);

            command.ExecuteNonQuery();
            
        }

        public void Set(Papel obj)
        {
            string commandText = @" UPDATE papel SET descricao = @descricao WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@descricao", obj.Descricao);

            command.ExecuteNonQuery();
        }

        public void Remove(Papel obj)
        {
            string commandText = @" DELETE FROM papel WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);

            command.ExecuteNonQuery();
        }

        public void Get(Papel obj)
        {
			string commandText = @" SELECT id, descricao FROM papel WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Papel> GetAll() 
		{
			string commandText = @" SELECT id, descricao FROM papel ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Papel.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
