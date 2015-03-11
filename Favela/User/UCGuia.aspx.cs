using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Favela.Library.Model;

namespace Favela.User
{
    public partial class UCGuia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }

            SetDataGuiasGrid();
        }

        private void SetDataGuiasGrid()
        {
            List<Funcionario> guias = new List<Funcionario>();
            guias = Funcionario.Repository.GetAllGuias();
            gvGuiaGrupo.DataSource = guias;
            gvGuiaGrupo.DataBind();
        }

        protected void btnConfirma(object sender, EventArgs e)
        {
            Funcionario novoGuia = new Funcionario();

            novoGuia.Email = txtEmail.Text.Trim();
            novoGuia.IdPapel = 4;
            novoGuia.Nome = txtNome.Text.Trim();
            novoGuia.Telefone = txtTel.Text.Trim();

            Funcionario.Repository.Add(novoGuia);

            ClearFields();
            SetDataGuiasGrid();
        }

        private void ClearFields()
        {
            txtEmail.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtTel.Text = String.Empty;
        }

        protected void gvGuiaGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}