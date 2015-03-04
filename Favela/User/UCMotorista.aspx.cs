using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Favela.Library.Model;

namespace Favela.User
{
    public partial class UCMotorista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            SetDataMotoristasGrid();
        }

        private void SetDataMotoristasGrid()
        {
            List<Funcionario> motoristas = new List<Funcionario>();
            motoristas = Funcionario.Repository.GetAllMotoristas();
            gvMotGrupo.DataSource = motoristas;
            gvMotGrupo.DataBind();
        }

        protected void btnConfirma(object sender, EventArgs e)
        {
            Funcionario novomotorista = new Funcionario();

            novomotorista.IdPapel = 5;
            //novomotorista.Matricula = String.Intern(txtNome.Text.Trim()).Substring(5,10);
            novomotorista.Nome = txtNome.Text.Trim();
            novomotorista.Telefone = txtTel.Text.Trim();

            Funcionario.Repository.Add(novomotorista);

            ClearFields();
        }

        private void ClearFields()
        {
            txtNome.Text = String.Empty;
            txtTel.Text = String.Empty;
        }
        protected void gvMotGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}