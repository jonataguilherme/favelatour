
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
    class GrupoAdoMysqlRepository : IGrupoRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public GrupoAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Grupo obj)
        {
            string commandText = @" INSERT INTO grupo ( matriculaMotorista, matriculaGuia, obs, status, matriculaFunc, invertido, quantidade, horario ) VALUES ( @matriculaMotorista, @matriculaGuia, @obs, @status, @matriculaFunc, @invertido, @quantidade, @horario )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@matriculaMotorista", obj.MatriculaMotorista);
			command.Parameters.Add("@matriculaGuia", obj.MatriculaGuia);
			command.Parameters.Add("@obs", obj.Obs);
			command.Parameters.Add("@status", obj.Status);
			command.Parameters.Add("@matriculaFunc", obj.MatriculaFunc);
			command.Parameters.Add("@invertido", obj.Invertido);
			command.Parameters.Add("@quantidade", obj.Quantidade);
			command.Parameters.Add("@horario", obj.Horario);

            command.ExecuteNonQuery();

            command.CommandText = @"SELECT @@IDENTITY";

            obj.IdGrupo = Convert.ToInt32(command.ExecuteScalar());
            
        }

        public void Set(Grupo obj)
        {
            string commandText = @" UPDATE grupo SET matriculaMotorista = @matriculaMotorista, matriculaGuia = @matriculaGuia, obs = @obs, status = @status, matriculaFunc = @matriculaFunc, invertido = @invertido, quantidade = @quantidade, horario = @horario WHERE (idGrupo = @idGrupo) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
			command.Parameters.Add("@matriculaMotorista", obj.MatriculaMotorista);
			command.Parameters.Add("@matriculaGuia", obj.MatriculaGuia);
			command.Parameters.Add("@obs", obj.Obs);
			command.Parameters.Add("@status", obj.Status);
			command.Parameters.Add("@matriculaFunc", obj.MatriculaFunc);
			command.Parameters.Add("@invertido", obj.Invertido);
			command.Parameters.Add("@quantidade", obj.Quantidade);
			command.Parameters.Add("@horario", obj.Horario);

            command.ExecuteNonQuery();
        }

        public void Remove(Grupo obj)
        {
            string commandText = @" DELETE FROM grupo WHERE (idGrupo = @idGrupo) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);

            command.ExecuteNonQuery();
        }

        public void Get(Grupo obj)
        {
			string commandText = @" SELECT idGrupo, matriculaMotorista, matriculaGuia, obs, status, matriculaFunc, invertido, quantidade, horario FROM grupo WHERE (idGrupo = @idGrupo) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@idGrupo", obj.IdGrupo);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Grupo> GetAll() 
		{
			string commandText = @" SELECT idGrupo, matriculaMotorista, matriculaGuia, obs, status, matriculaFunc, invertido, quantidade, horario FROM grupo ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Grupo.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
