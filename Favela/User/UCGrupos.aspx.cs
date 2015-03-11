using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Favela.Library.Model;
using System.Collections;

namespace Favela.User
{
    public partial class UCGrupos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetGuiasDropDownList();
                this.SetMotoristasDropDownList();
                SetDataReservasGrid();
                SetDataGruposGrid();
            }
        }

        private void SetMotoristasDropDownList()
        {
            List<Funcionario> motoristasCadastrados = new List<Funcionario>();

            motoristasCadastrados = Funcionario.Repository.GetAllMotoristas();

            foreach (Funcionario motorista in motoristasCadastrados)
            {
                ListItem item = new ListItem(motorista.Nome, motorista.Matricula.ToString());
                cmbMotorista.Items.Add(item);
            }

            cmbMotorista.SelectedValue = "0";
        }

        private void SetGuiasDropDownList()
        {
            List<Funcionario> guiasCadastrados = new List<Funcionario>();

            guiasCadastrados = Funcionario.Repository.GetAllGuias();

            foreach (Funcionario guia in guiasCadastrados)
            {
                ListItem item = new ListItem(guia.Nome, guia.Matricula.ToString());
                cmbGuia.Items.Add(item);
            }

            cmbGuia.SelectedValue = "0";
        }

        private void SetDataGruposGrid()
        {
            List<Grupo> gruposCadastradas = new List<Grupo>();
            gruposCadastradas = Grupo.Repository.GetAll();
            gvGrupoGer.DataSource = gruposCadastradas;
            gvGrupoGer.DataBind();

        }

        private void SetDataReservasGrid()
        {
            List<Reserva> reservasCadastradas = new List<Reserva>();
            reservasCadastradas = Reserva.Repository.GetAll();
            gvGerGrupo.DataSource = reservasCadastradas;
            gvGerGrupo.DataBind();
        }

        protected void btnAlterar_onClick(object sender, EventArgs e)
        {
            
        }

        protected void btnExcluir_onClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Grupo grup = new Grupo();
            grup.IdGrupo = int.Parse(btn.CommandArgument);

            Grupo.Repository.Remove(grup);
        }
        
        protected void btnGerarGrupo_Click(object sender, EventArgs e)
        {
            IEnumerator gerGrupoIterator = gvGerGrupo.Rows.GetEnumerator();
            List<int> ids = new List<int>();
            int qtd = 0;

            while (gerGrupoIterator.MoveNext())
            {
                GridViewRow row = (GridViewRow)gerGrupoIterator.Current;
                CheckBox chk = (CheckBox)row.Cells[5].FindControl("chkIncluir");
                
                if (chk.Checked)
                {
                    Label lblId = (Label)row.Cells[5].FindControl("lblID");
                    ids.Add(Int32.Parse(lblId.Text));
                    qtd += Int32.Parse(row.Cells[3].Text);
                }
            }

            Grupo novoGrupo = new Grupo();

            novoGrupo.MatriculaGuia = Int32.Parse(cmbGuia.SelectedValue);
            novoGrupo.MatriculaMotorista = Int32.Parse(cmbMotorista.SelectedValue);
            novoGrupo.Horario = String.Empty;
            novoGrupo.Invertido = false;
            novoGrupo.MatriculaFunc = Int32.Parse(cmbGuia.SelectedValue);
            novoGrupo.Obs = String.Empty;
            novoGrupo.Quantidade = qtd;
            novoGrupo.Status = 1;

            Grupo.Repository.Add(novoGrupo);

            foreach (int id in ids)
            {
                Gruporeserva gr = new Gruporeserva();
                gr.IdGrupo = novoGrupo.IdGrupo;
                gr.IdReserva = id;
                Gruporeserva.Repository.Add(gr);
            }
        }

        protected void gvGerGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGrupoGer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGerGrupo_DataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Idioma i = new Idioma();
                i.Id = int.Parse(e.Row.Cells[2].Text);
                Idioma.Repository.Get(i);
                e.Row.Cells[2].Text = i.Descricao;

                Hotel h = new Hotel();
                h.Id = int.Parse(e.Row.Cells[4].Text);
                if (h.Id == 0)
                {
                    e.Row.Cells[4].Text = "Não cadastrado";
                    e.Row.Cells[5].Enabled = false;
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    Hotel.Repository.Get(h);
                    e.Row.Cells[4].Text = h.Nome;
                }
            }
        }

        protected void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            IEnumerator gerGrupoIterator = gvGerGrupo.Rows.GetEnumerator();
            int qtd = 0;

            while (gerGrupoIterator.MoveNext())
            {
                GridViewRow row = (GridViewRow)gerGrupoIterator.Current;
                CheckBox chkl = (CheckBox)row.Cells[5].FindControl("chkIncluir");

                if (chkl.Checked)
                {
                    qtd += Int32.Parse(row.Cells[3].Text);
                }
            }

            Response.Write("<script>alert('Quantidade de visitantes selecionados até o momento:"+ qtd +" ');</script>");
            
        }

        protected void gvGrupoGer_DataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Funcionario func = new Funcionario();

                func.Matricula = Int32.Parse(e.Row.Cells[1].Text);
                Funcionario.Repository.Get(func);
                e.Row.Cells[1].Text = func.Nome;

                func.Matricula = Int32.Parse(e.Row.Cells[2].Text);
                Funcionario.Repository.Get(func);
                e.Row.Cells[2].Text = func.Nome;
            }
        }

    }
}