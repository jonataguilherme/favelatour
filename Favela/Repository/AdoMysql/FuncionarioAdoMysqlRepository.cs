
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
    class FuncionarioAdoMysqlRepository : IFuncionarioRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public FuncionarioAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Funcionario obj)
        {
            string commandText = @" INSERT INTO funcionario ( matricula, nome, telefone, email, idPapel ) VALUES ( @matricula, @nome, @telefone, @email, @idPapel )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@matricula", obj.Matricula);
			command.Parameters.Add("@nome", obj.Nome);
			command.Parameters.Add("@telefone", obj.Telefone);
			command.Parameters.Add("@email", obj.Email);
			command.Parameters.Add("@idPapel", obj.IdPapel);

            command.ExecuteNonQuery();
            
        }

        public void Set(Funcionario obj)
        {
            string commandText = @" UPDATE funcionario SET nome = @nome, telefone = @telefone, email = @email, idPapel = @idPapel WHERE (matricula = @matricula) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@matricula", obj.Matricula);
			command.Parameters.Add("@nome", obj.Nome);
			command.Parameters.Add("@telefone", obj.Telefone);
			command.Parameters.Add("@email", obj.Email);
			command.Parameters.Add("@idPapel", obj.IdPapel);

            command.ExecuteNonQuery();
        }

        public void Remove(Funcionario obj)
        {
            string commandText = @" DELETE FROM funcionario WHERE (matricula = @matricula) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@matricula", obj.Matricula);

            command.ExecuteNonQuery();
        }

        public void Get(Funcionario obj)
        {
			string commandText = @" SELECT matricula, nome, telefone, email, idPapel FROM funcionario WHERE (matricula = @matricula) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@matricula", obj.Matricula);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Funcionario> GetAll() 
		{
			string commandText = @" SELECT matricula, nome, telefone, email, idPapel FROM funcionario ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Funcionario.GetList(dt);
		}

		#endregion GeneratedCode


        public List<Funcionario> GetAllGuias()
        {
            string commandText = @" SELECT matricula, nome, telefone, email, idPapel FROM funcionario WHERE idPapel = 4";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

            return Funcionario.GetList(dt);
        }


        public List<Funcionario> GetAllMotoristas()
        {
            string commandText = @" SELECT matricula, nome, telefone, email, idPapel FROM funcionario WHERE idPapel = 5";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

            return Funcionario.GetList(dt);
        }

    }
}
