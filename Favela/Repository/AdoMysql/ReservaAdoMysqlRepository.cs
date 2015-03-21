
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
    class ReservaAdoMysqlRepository : IReservaRepository
    {

		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public ReservaAdoMysqlRepository(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

		public void Add(Reserva obj)
        {
            string commandText = @" INSERT INTO reserva ( dataHora, idTurno, idIdioma, privativo, nomeCliente, email, quantidade, noHotel, idHotel, apartamento, origemPrecoContato, pais, grupo ) VALUES ( @dataHora, @idTurno, @idIdioma, @privativo, @nomeCliente, @email, @quantidade, @noHotel, @idHotel, @apartamento, @origemPrecoContato, @pais, @grupo )";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@dataHora", obj.DataHora);
			command.Parameters.Add("@idTurno", obj.IdTurno);
			command.Parameters.Add("@idIdioma", obj.IdIdioma);
			command.Parameters.Add("@privativo", obj.Privativo);
			command.Parameters.Add("@nomeCliente", obj.NomeCliente);
			command.Parameters.Add("@email", obj.Email);
			command.Parameters.Add("@quantidade", obj.Quantidade);
			command.Parameters.Add("@noHotel", obj.NoHotel);
			command.Parameters.Add("@idHotel", obj.IdHotel);
			command.Parameters.Add("@apartamento", obj.Apartamento);
			command.Parameters.Add("@origemPrecoContato", obj.OrigemPrecoContato);
			command.Parameters.Add("@pais", obj.Pais);
            command.Parameters.Add("@grupo", obj.Grupo);

            command.ExecuteNonQuery();
            
        }

        public void Set(Reserva obj)
        {
            string commandText = @" UPDATE reserva SET dataHora = @dataHora, idTurno = @idTurno, idIdioma = @idIdioma, privativo = @privativo, nomeCliente = @nomeCliente, email = @email, quantidade = @quantidade, noHotel = @noHotel, idHotel = @idHotel, apartamento = @apartamento, origemPrecoContato = @origemPrecoContato, pais = @pais, grupo = @grupo WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
			command.Parameters.Add("@dataHora", obj.DataHora);
			command.Parameters.Add("@idTurno", obj.IdTurno);
			command.Parameters.Add("@idIdioma", obj.IdIdioma);
			command.Parameters.Add("@privativo", obj.Privativo);
			command.Parameters.Add("@nomeCliente", obj.NomeCliente);
			command.Parameters.Add("@email", obj.Email);
			command.Parameters.Add("@quantidade", obj.Quantidade);
			command.Parameters.Add("@noHotel", obj.NoHotel);
			command.Parameters.Add("@idHotel", obj.IdHotel);
			command.Parameters.Add("@apartamento", obj.Apartamento);
			command.Parameters.Add("@origemPrecoContato", obj.OrigemPrecoContato);
			command.Parameters.Add("@pais", obj.Pais);
            command.Parameters.Add("@grupo", obj.Grupo);

            command.ExecuteNonQuery();
        }

        public void Remove(Reserva obj)
        {
            string commandText = @" DELETE FROM reserva WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);

            command.ExecuteNonQuery();
        }

        public void Get(Reserva obj)
        {
			string commandText = @" SELECT id, dataHora, idTurno, idIdioma, privativo, nomeCliente, email, quantidade, noHotel, idHotel, apartamento, origemPrecoContato, pais, grupo FROM reserva WHERE (id = @id) ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

			command.Parameters.Add("@id", obj.Id);
            DataTable dt = command.ExecuteReader();

            if (dt.Rows.Count > 0) obj.Load(dt.Rows[0]);
        }

		public List<Reserva> GetAll() 
		{
			string commandText = @" SELECT id, dataHora, idTurno, idIdioma, privativo, nomeCliente, email, quantidade, noHotel, idHotel, apartamento, origemPrecoContato, pais, grupo FROM reserva ";

            AdoMysqlCommand command = new AdoMysqlCommand(this.ConnectionString, commandText);

            DataTable dt = command.ExecuteReader();

			return Reserva.GetList(dt);
		}

		#endregion GeneratedCode
    }
}
