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
    public partial class UCReserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetHotelDropDownList();
                this.SetIdiomaDropDownList();

                this.SetGuiasDropDownList();
                this.SetMotoristasDropDownList();

                txtCalendario.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }

            SetDataReservasGrid();
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

        private void SetDataReservasGrid()
        {
            List<Reserva> reservasCadastradas = new List<Reserva>();
            reservasCadastradas = Reserva.Repository.GetAll();
            gvGerGrupo.DataSource = reservasCadastradas;
            gvGerGrupo.DataBind();
        }

        protected void ckbNoHotel_CheckedChanged(object sender, EventArgs e)
        {
            //cmbHotel.Enabled = !cmbHotel.Enabled;
            txtApto.Enabled = !ckbNoHotel.Checked;
        }

        private void SetIdiomaDropDownList()
        {
            List<Idioma> idiomasCadastrados = new List<Idioma>();

            idiomasCadastrados = Idioma.Repository.GetAll();

            foreach (Idioma idioma in idiomasCadastrados)
            {
                ListItem item = new ListItem(idioma.Descricao, idioma.Id.ToString());
                cmbIdioma.Items.Add(item);
            }

            cmbIdioma.SelectedValue = "1";
        }

        private void SetHotelDropDownList()
        {
            List<Hotel> hoteisCadastrados = new List<Hotel>();

            hoteisCadastrados = Hotel.Repository.GetAll();

            foreach (Hotel hotel in hoteisCadastrados)
            {
                ListItem item = new ListItem(hotel.Nome, hotel.Id.ToString());
                cmbHotel.Items.Add(item);
            }

        }

        protected void btnInserir_Click(object sender, EventArgs e)
        {
            //Verificar se campos preenchidos corretamente
            //senão Response.Write("<script>alert('Alguns campos não foram preenchidos!!');</script>");

            Button btn = (Button)sender;
            switch (btn.CommandName)
            {
                case "insere":
                    doNewReserva();
                    break;
                case "cancela":
                    showBtnInserir();
                    break;
                case "altera":
                    doChangeReserva();
                    break;
                default:
                    break;
            }

            clearFields();

        }

        private void clearFields()
        {
            txtApto.Text = string.Empty;
            txtCliente.Text = string.Empty;
            txtInfo.Text = string.Empty;
            txtQuantidade.Text = string.Empty;

            cmbHotel.SelectedValue = "1";
            cmbIdioma.SelectedValue = "1";
            //cmbTurno.SelectedValue = "1";

            ckbNoHotel.Checked = false;
            ckbPrivado.Checked = false;
        }

        private void doChangeReserva()
        {
            Reserva novaReserva = new Reserva();

            getDataFromFields(novaReserva);

            if (!ckbNoHotel.Checked)
            {
                novaReserva.Apartamento = null;
            }

            novaReserva.Id = int.Parse(hdnId.Text);

            try
            {
                Reserva.Repository.Set(novaReserva);
                Response.Write("<script>alert('Alterado com sucesso!!');</script>");
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Ocorreu o seguinte erro:" + e.Message + "');</script>");
            }
        }

        private void doNewReserva()
        {
            Reserva novaReserva = new Reserva();

            getDataFromFields(novaReserva);

            try
            {
                Reserva.Repository.Add(novaReserva);
                Response.Write("<script>alert('Cadastrado com sucesso!!');</script>");
            }
            catch (Exception e)
            {
                Response.Write("<script>alert('Ocorreu o seguinte erro:" + e.Message + "');</script>");
            }
        }

        private void getDataFromFields(Reserva novaReserva)
        {
            novaReserva.NoHotel = ckbNoHotel.Checked;

            if (ckbNoHotel.Checked)
            {
                novaReserva.Apartamento = txtApto.Text;
            }

            novaReserva.IdHotel = Convert.ToInt32(cmbHotel.SelectedValue);

            int hour = Convert.ToInt32(txtHorario.Text.Substring(0, 2).Replace(":", "").Trim());
            int minute = Convert.ToInt32(txtHorario.Text.Replace(":", "").Trim());
            minute %= 100;

            novaReserva.DataHora = new DateTime(cldCalendario.SelectedDate.Year, cldCalendario.SelectedDate.Month, cldCalendario.SelectedDate.Day, hour, minute, 00);
            //novaReserva.Email = txtEmail.Text;
            novaReserva.IdIdioma = Convert.ToInt32(cmbIdioma.SelectedValue);
            novaReserva.IdTurno = Convert.ToInt32(cmbTurno.SelectedValue);
            novaReserva.NomeCliente = txtCliente.Text;
            novaReserva.OrigemPrecoContato = txtInfo.Text;
            novaReserva.Quantidade = Convert.ToInt32(txtQuantidade.Text);
            novaReserva.Privativo = ckbPrivado.Checked;
        }

        protected void btnAlterar_onClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Reserva res = new Reserva();
            res.Id = int.Parse(btn.CommandArgument);
            Reserva.Repository.Get(res);

            FillFields(res);

            hideBtnInserir();
        }

        private void hideBtnInserir()
        {
            btnConfirmaAlterar.Visible = true;
            btnCancelar.Visible = true;
            btnInserir.Visible = false;
        }

        private void showBtnInserir()
        {
            btnConfirmaAlterar.Visible = false;
            btnCancelar.Visible = false;
            btnInserir.Visible = true;
        }

        private void FillFields(Reserva res)
        {
            cmbIdioma.SelectedValue = res.IdIdioma.ToString();
            cmbHotel.SelectedValue = res.IdHotel.ToString();
            cmbTurno.SelectedValue = res.IdTurno.ToString();

            txtApto.Text = res.Apartamento;
            txtCalendario.Text = res.DataHora.ToString("dd/MM/yyyy");
            txtCliente.Text = res.NomeCliente;
            txtHorario.Text = res.DataHora.ToString("hh:mm");
            txtInfo.Text = res.OrigemPrecoContato;
            txtQuantidade.Text = res.Quantidade.ToString();

            ckbNoHotel.Checked = res.NoHotel;
            ckbPrivado.Checked = res.Privativo;

            hdnId.Text = res.Id.ToString();
        }

        protected void btnExcluir_onClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Reserva res = new Reserva();
            res.Id = int.Parse(btn.CommandArgument);

            Reserva.Repository.Remove(res);
        }
        
        protected void gvGerGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        { 
        
        }

        protected void gvGrupoGer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        
        /*protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }*/

        protected void LBCalendario_Click(object sender, EventArgs e)
        {
            cldCalendario.Visible = true;
            LBCalendario.Visible = false;
        }

        protected void cldCalendario_Click(object sender, EventArgs e)
        {
            txtCalendario.Text = cldCalendario.SelectedDate.ToString("dd/MM/yyyy");
            txtCalendario.Visible = true;
            cldCalendario.Visible = false;
            LBCalendario.Visible = true;
        }

        protected void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        protected void gvGerGrupo_DataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Horário
                e.Row.Cells[0].Text = DateTime.Parse(e.Row.Cells[0].Text).ToString("hh:MM");

                //Idioma
                Idioma i = new Idioma();
                i.Id = int.Parse(e.Row.Cells[3].Text);
                Idioma.Repository.Get(i);
                e.Row.Cells[3].Text = i.Descricao;

                //Privativo
                bool pvd = bool.Parse(e.Row.Cells[4].Text);
                if (pvd)
                {
                    e.Row.Cells[4].Text = "S";
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                else
                    e.Row.Cells[4].Text = String.Empty;

                //NO
                bool NO = bool.Parse(e.Row.Cells[5].Text);
                if (NO)
                    e.Row.Cells[5].Text = "S";
                else
                    e.Row.Cells[5].Text = String.Empty;

                //Hotel
                Hotel h = new Hotel();
                h.Id = int.Parse(e.Row.Cells[6].Text);
                if (h.Id == 0)
                {
                    e.Row.Cells[6].Text = "Não cadastrado";
                    e.Row.ForeColor = System.Drawing.Color.White;
                    e.Row.BackColor = System.Drawing.Color.Red;
                }
                else
                {
                    Hotel.Repository.Get(h);
                    e.Row.Cells[6].Text = h.Nome;
                }
            }
        }
        
    }
}