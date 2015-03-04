
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Favela.Library.Repository
{
    [Serializable]
    public abstract partial class RepositoryFactory
    {
		#region GeneratedCode

		#region Repository Factories

		public static RepositoryFactory Default()
		{
			return new AdoMysql.AdoMysqlRepositoryFactory();
		}

		#endregion Repository Factories

		#region Entity Repositories

		public abstract IFuncionarioRepository NewFuncionarioRepository ();

		public abstract IGrupoRepository NewGrupoRepository ();

		public abstract IGruporeservaRepository NewGruporeservaRepository ();

		public abstract IHotelRepository NewHotelRepository ();

		public abstract IIdiomaRepository NewIdiomaRepository ();

		public abstract IPapelRepository NewPapelRepository ();

		public abstract IReservaRepository NewReservaRepository ();

		public abstract IStatusRepository NewStatusRepository ();

		#endregion Entity Repositories

		#endregion GeneratedCode
    }
}
