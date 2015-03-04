
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Model;
using Favela.Library.Repository;
using System.Configuration;

namespace Favela.Library.Repository.AdoMysql
{
    [Serializable]
    class AdoMysqlRepositoryFactory : RepositoryFactory
    {
		#region GeneratedCode

		public string ConnectionString 
        { 
            get; 
            set; 
        }

        public AdoMysqlRepositoryFactory()
        {
            if (ConfigurationManager.ConnectionStrings["AdoMysql"] == null)  
                throw new InvalidOperationException("Não foi encontrada uma connectionstring para a criação de RepositoryFactory.");

            this.ConnectionString = ConfigurationManager.ConnectionStrings["AdoMysql"].ToString(); ;
        }

		#region Entity Repositories

		public override IFuncionarioRepository NewFuncionarioRepository ()
		{
			return new FuncionarioAdoMysqlRepository(this.ConnectionString);
		}

		public override IGrupoRepository NewGrupoRepository ()
		{
			return new GrupoAdoMysqlRepository(this.ConnectionString);
		}

		public override IGruporeservaRepository NewGruporeservaRepository ()
		{
			return new GruporeservaAdoMysqlRepository(this.ConnectionString);
		}

		public override IHotelRepository NewHotelRepository ()
		{
			return new HotelAdoMysqlRepository(this.ConnectionString);
		}

		public override IIdiomaRepository NewIdiomaRepository ()
		{
			return new IdiomaAdoMysqlRepository(this.ConnectionString);
		}

		public override IPapelRepository NewPapelRepository ()
		{
			return new PapelAdoMysqlRepository(this.ConnectionString);
		}

		public override IReservaRepository NewReservaRepository ()
		{
			return new ReservaAdoMysqlRepository(this.ConnectionString);
		}

		public override IStatusRepository NewStatusRepository ()
		{
			return new StatusAdoMysqlRepository(this.ConnectionString);
		}

		#endregion Entity Repositories

		#endregion GeneratedCode
    }
}
