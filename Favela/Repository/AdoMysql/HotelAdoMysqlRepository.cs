
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
    class HotelAdoMysqlRepository : IHotelRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public HotelAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Hotel obj)
        {
            string commandText = @" INSERT INTO hotel ( nome ) VALUES ( @nome )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@nome", obj.Nome);

            command.ExecuteNonQuery();
            
        }

        public void Set(Hotel obj)
        {
            string commandText = @" UPDATE hotel SET nome = @nome WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@nome", obj.Nome);

            command.ExecuteNonQuery();
        }

        public void Remove(Hotel obj)
        {
            string commandText = @" DELETE FROM hotel WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);

            command.ExecuteNonQuery();
        }

        public void Get(Hotel obj)
        {
			string commandText = @" SELECT id, nome FROM hotel WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Hotel> GetAll() 
		{
			string commandText = @" SELECT id, nome FROM hotel ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Hotel.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
