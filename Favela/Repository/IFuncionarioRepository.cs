
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Favela.Library.Model;

namespace Favela.Library.Repository
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
		#region GeneratedCode

		#endregion GeneratedCode
        
        List<Funcionario> GetAllGuias();

        List<Funcionario> GetAllMotoristas();
    }
}
