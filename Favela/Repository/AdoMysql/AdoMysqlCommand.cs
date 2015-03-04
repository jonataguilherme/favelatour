

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Favela.Library.Repository.AdoMysql
{
    class AdoMysqlCommand
    {
        public string ConnectionString 
        {
            get; 
            set; 
        }

        private MySqlConnection _Connection;

        public MySqlConnection Connection
        {
            get
            {
                return _Connection;
            }
        }

        public CommandType CommandType 
        { 
            get; 
            set; 
        }

        private string _CommandText;

        public string CommandText 
        {
            get
            {
                return _CommandText;
            }
            set
            {
                Parameters.Clear();

                _CommandText = value;
            }
        }

        public Dictionary<string, object> Parameters 
        { 
            get; 
            set; 
        }

        public AdoMysqlCommand(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
            this.CommandType = System.Data.CommandType.Text;
            this.Parameters = new Dictionary<string, object>();
        }

        public AdoMysqlCommand(string ConnectionString, string commandText)
        {
            this.ConnectionString = ConnectionString;
            this.CommandType = System.Data.CommandType.Text;
            this.Parameters = new Dictionary<string, object>();
            this.CommandText = commandText;
        }

        public AdoMysqlCommand(string ConnectionString, string commandText, Dictionary<string, object> parameters)
        {
            this.ConnectionString = ConnectionString;
            this.CommandType = System.Data.CommandType.Text;
            this.Parameters = new Dictionary<string, object>();
            this.CommandText = commandText;
            this.Parameters = parameters;
        }

        public void ExecuteNonQuery() 
        {
            using (_Connection = new MySqlConnection(ConnectionString))
            {
                _Connection.Open();

                using (MySqlCommand command = new MySqlCommand(CommandText, _Connection))
                {
                    PrepareParameters(command);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void PrepareParameters(MySqlCommand command)
        {
            command.CommandType = this.CommandType;

            foreach (string key in Parameters.Keys)
            {
                object value = Parameters[key];

                if (value == null)
                {
                    value = DBNull.Value;
                }

                command.Parameters.AddWithValue(key, value);
            }
        }

        public void ExecuteNonQuery(string commandText)
        {
            this.CommandText = commandText;

            ExecuteNonQuery();
        }

        public void ExecuteNonQuery(string commandText, Dictionary<string, object> parameters)
        {
            this.CommandText = commandText;
            this.Parameters = parameters;

            ExecuteNonQuery();
        }

        public object ExecuteScalar()
        {
            using (_Connection = new MySqlConnection(ConnectionString))
            {
                _Connection.Open();

                using (MySqlCommand command = new MySqlCommand(CommandText, _Connection))
                {
                    PrepareParameters(command);

                    return command.ExecuteScalar();
                }
            }
        } 

        public object ExecuteScalar(string commandText)
        {
            this.CommandText = commandText;

            return ExecuteScalar();
        }

        public object ExecuteScalar(string commandText, Dictionary<string, object> parameters)
        {
            this.CommandText = commandText;
            this.Parameters = parameters;

            return ExecuteScalar();
        }

        public DataTable ExecuteReader()
        {
            MySqlDataAdapter dataAdapter;
            DataTable dataTable = new DataTable();

            using (_Connection = new MySqlConnection(ConnectionString))
            {
                _Connection.Open();

                using (MySqlCommand command = new MySqlCommand(CommandText, _Connection))
                {
                    PrepareParameters(command);

                    dataAdapter = new MySqlDataAdapter(command);
                    dataAdapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public DataTable ExecuteReader(string commandText)
        {
            this.CommandText = commandText;

            return ExecuteReader();
        }

        public DataTable ExecuteReader(string commandText, Dictionary<string, object> parameters)
        {
            this.CommandText = commandText;
            this.Parameters = parameters;

            return ExecuteReader();
        }

		public DateTime CurrentDatabaseDate()
		{
			return Convert.ToDateTime(ExecuteScalar("select now();"));
		}
    }
}
