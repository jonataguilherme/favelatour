
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
    class StatusAdoMysqlRepository : IStatusRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public StatusAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Status obj)
        {
            string commandText = @" INSERT INTO status ( nome ) VALUES ( @nome )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@nome", obj.Nome);

            command.ExecuteNonQuery();
            
        }

        public void Set(Status obj)
        {
            string commandText = @" UPDATE status SET nome = @nome WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@nome", obj.Nome);

            command.ExecuteNonQuery();
        }

        public void Remove(Status obj)
        {
            string commandText = @" DELETE FROM status WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);

            command.ExecuteNonQuery();
        }

        public void Get(Status obj)
        {
			string commandText = @" SELECT id, nome FROM status WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Status> GetAll() 
		{
			string commandText = @" SELECT id, nome FROM status ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Status.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
