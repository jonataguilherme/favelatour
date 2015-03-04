
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
    class IdiomaAdoMysqlRepository : IIdiomaRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public IdiomaAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Idioma obj)
        {
            string commandText = @" INSERT INTO idioma ( descricao ) VALUES ( @descricao )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@descricao", obj.Descricao);

            command.ExecuteNonQuery();
            
        }

        public void Set(Idioma obj)
        {
            string commandText = @" UPDATE idioma SET descricao = @descricao WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@descricao", obj.Descricao);

            command.ExecuteNonQuery();
        }

        public void Remove(Idioma obj)
        {
            string commandText = @" DELETE FROM idioma WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);

            command.ExecuteNonQuery();
        }

        public void Get(Idioma obj)
        {
			string commandText = @" SELECT id, descricao FROM idioma WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Idioma> GetAll() 
		{
			string commandText = @" SELECT id, descricao FROM idioma ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Idioma.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
