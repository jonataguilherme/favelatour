using System;
using System.Globalization;
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
        int tempQtdd = 0;
        List<Reserva> reservasCadastradas = new List<Reserva>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.SetHotelDropDownList();
                this.SetIdiomaDropDownList();

                this.SetGuiasDropDownList();
                this.SetMotoristasDropDownList();

                txtCalendario.Text = DateTime.Now.ToString("yyyy/MM/dd");
                SetDataReservasGrid();
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
                cmbMotorista_0.Items.Add(item);
                cmbMotorista_1.Items.Add(item);
                cmbMotorista_2.Items.Add(item);
                cmbMotorista_3.Items.Add(item);
                cmbMotorista_4.Items.Add(item);
            }

            cmbMotorista_0.SelectedValue = "0";
            cmbMotorista_1.SelectedValue = "0";
            cmbMotorista_2.SelectedValue = "0";
            cmbMotorista_3.SelectedValue = "0";
            cmbMotorista_4.SelectedValue = "0";
        }

        private void SetGuiasDropDownList()
        {
            List<Funcionario> guiasCadastrados = new List<Funcionario>();

            guiasCadastrados = Funcionario.Repository.GetAllGuias();

            foreach (Funcionario guia in guiasCadastrados)
            {
                ListItem item = new ListItem(guia.Nome, guia.Matricula.ToString());
                cmbGuia_0.Items.Add(item);
                cmbGuia_1.Items.Add(item);
                cmbGuia_2.Items.Add(item);
                cmbGuia_3.Items.Add(item);
                cmbGuia_4.Items.Add(item);
                
            }

            cmbGuia_0.SelectedValue = "0";
            cmbGuia_1.SelectedValue = "0";
            cmbGuia_2.SelectedValue = "0";
            cmbGuia_3.SelectedValue = "0";
            cmbGuia_4.SelectedValue = "0";
        }

        private void SetDataReservasGrid()
        {
            reservasCadastradas = Reserva.Repository.GetAll();
            gvGerGrupo.DataSource = reservasCadastradas;
            gvGerGrupo.DataBind();
            gvGerGrupo_1.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            gvGerGrupo_1.DataBind();// onde acrescentei as o que vc falou
            gvGerGrupo_2.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            gvGerGrupo_2.DataBind();// onde acrescentei as o que vc falou
            gvGerGrupo_3.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            gvGerGrupo_3.DataBind();// onde acrescentei as o que vc falou
            gvGerGrupo_4.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            gvGerGrupo_4.DataBind();// onde acrescentei as o que vc falou
            //gvGerGrupo_5.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            //gvGerGrupo_5.DataBind();// onde acrescentei as o que vc falou
            //gvGerGrupo_6.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            //gvGerGrupo_6.DataBind();// onde acrescentei as o que vc falou
            //gvGerGrupo_7.DataSource = reservasCadastradas;// onde acrescentei as o que vc falou
            //gvGerGrupo_7.DataBind();// onde acrescentei as o que vc falou
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

            SetDataReservasGrid();

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

            if (!ckbNoHotel.Checked)
            {
                novaReserva.Apartamento = txtApto.Text;
            }

            novaReserva.IdHotel = Convert.ToInt32(cmbHotel.SelectedValue);

            novaReserva.Grupo = Convert.ToInt32(ddlGrupo.SelectedValue);
            novaReserva.DataHora = DateTime.Parse(txtCalendario.Text).Add(TimeSpan.Parse(txtHorario.Text));
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
            txtCalendario.Text = res.DataHora.ToString("yyyy/MM/dd");
            txtCliente.Text = res.NomeCliente;
            txtHorario.Text = res.DataHora.ToString("HH:mm");
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
            SetDataReservasGrid();
        }
        
        protected void gvGerGrupo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        { 
        
        }

        protected void gvGrupoGer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
        
        protected void LBCalendario_Click(object sender, EventArgs e)
        {
            cldCalendario.Visible = true;
            LBCalendario.Visible = false;
        }

        protected void cldCalendario_Click(object sender, EventArgs e)
        {
            txtDataAnterior.Text = txtCalendario.Text;
            DateTime selectedDate = cldCalendario.SelectedDate;
            changeTxtCalendario(selectedDate);

        }

        private void changeTxtCalendario(DateTime selectedDate)
        {
            TimeSpan dateDiff = selectedDate.Subtract(DateTime.Now);
            if (dateDiff > (new TimeSpan(75, 0, 0, 0)))
            {
                Response.Write("<script>alert('Selecione uma data de até 75 dias à frente');</script>");
            }
            else
            {
                txtCalendario.Text = selectedDate.ToString("yyyy/MM/dd");
                txtCalendario.Visible = true;
                cldCalendario.Visible = false;
                LBCalendario.Visible = true;
                SetDataReservasGrid();
            }

        }

        protected void chkIncluir_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        protected void trataTempQtdd(int idCurrent)
        {
            if (idCurrent == reservasCadastradas[0].Id)
                tempQtdd = 0;
        }

        //Grupo 1
        protected void gvGerGrupo_DataBound(object sender, GridViewRowEventArgs e)
        {
            //Torna 0 variável de contagem quando o índice corrente for o menor índice na grid
            trataTempQtdd(e.Row.RowIndex);
            
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Grupo: Item 9 invisível
                int showingGrupo = Int32.Parse(ddlShowingGrupo.SelectedValue);
                if (Int32.Parse(e.Row.Cells[9].Text) != showingGrupo)
                    e.Row.Visible = false;
                else
                {
                    //Data: Item 10 invisível
                    DateTime dataHora = DateTime.Parse(e.Row.Cells[10].Text);
                    if (DateTime.Compare(DateTime.Parse(txtCalendario.Text), DateTime.Parse(dataHora.ToString("yyyy/MM/dd"))) != 0)
                        e.Row.Visible = false;
                    else
                    {
                        //Turno: Item 11 invisível
                        if (Int32.Parse(e.Row.Cells[11].Text) != Int32.Parse(cmbTurno.SelectedValue))
                            e.Row.Visible = false;
                        else
                        {
                            //Horário: Item 0
                            e.Row.Cells[0].Text = dataHora.ToString("HH:mm");

                            //Quantidade: Item 1
                            tempQtdd += Int32.Parse(e.Row.Cells[1].Text);

                            //Idioma: Item 3
                            Idioma i = new Idioma();
                            i.Id = int.Parse(e.Row.Cells[3].Text);
                            Idioma.Repository.Get(i);
                            e.Row.Cells[3].Text = i.Descricao;

                            //Privativo: Item 4
                            bool pvd = bool.Parse(e.Row.Cells[4].Text);
                            if (pvd)
                            {
                                e.Row.Cells[4].Text = "S";
                                e.Row.ForeColor = System.Drawing.Color.White;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                            else
                                e.Row.Cells[4].Text = String.Empty;

                            //NO: Item 5
                            bool NO = bool.Parse(e.Row.Cells[5].Text);
                            if (NO)
                                e.Row.Cells[5].Text = "S";
                            else
                                e.Row.Cells[5].Text = String.Empty;

                            //Hotel: Item 6
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

            lblQuantidadeGrupo_0.Text = " " + tempQtdd.ToString();

        }

        protected void btnEviar_Click(object sender, EventArgs e)
        {

        }

        protected void btnEncerrar_Click(object sender, EventArgs e)
        {

        }

        //nova informação
        //Grupo 2
        protected void gvGerGrupo_PageIndexChanging_1(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGrupoGer_PageIndexChanging_1(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGerGrupo_DataBound_1(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Grupo: Item 9 invisível
                int showingGrupo = Int32.Parse(ddlShowingGrupo_1.SelectedValue);
                if (Int32.Parse(e.Row.Cells[9].Text) != showingGrupo)
                    e.Row.Visible = false;
                else
                {
                    //Data: Item 10 invisível
                    DateTime dataHora = DateTime.Parse(e.Row.Cells[10].Text);
                    if (DateTime.Compare(DateTime.Parse(txtCalendario.Text), DateTime.Parse(dataHora.ToString("yyyy/MM/dd"))) != 0)
                        e.Row.Visible = false;
                    else
                    {
                        //Turno: Item 11 invisível
                        if (Int32.Parse(e.Row.Cells[11].Text) != Int32.Parse(cmbTurno.SelectedValue))
                            e.Row.Visible = false;
                        else
                        {


                            //Horário: Item 0
                            e.Row.Cells[0].Text = dataHora.ToString("HH:mm");

                            //Idioma: Item 3
                            Idioma i = new Idioma();
                            i.Id = int.Parse(e.Row.Cells[3].Text);
                            Idioma.Repository.Get(i);
                            e.Row.Cells[3].Text = i.Descricao;

                            //Privativo: Item 4
                            bool pvd = bool.Parse(e.Row.Cells[4].Text);
                            if (pvd)
                            {
                                e.Row.Cells[4].Text = "S";
                                e.Row.ForeColor = System.Drawing.Color.White;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                            else
                                e.Row.Cells[4].Text = String.Empty;

                            //NO: Item 5
                            bool NO = bool.Parse(e.Row.Cells[5].Text);
                            if (NO)
                                e.Row.Cells[5].Text = "S";
                            else
                                e.Row.Cells[5].Text = String.Empty;

                            //Hotel: Item 6
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
        }
        protected void btnEviar_Click_1(object sender, EventArgs e)
        {

        }

        protected void btnEncerrar_Click_1(object sender, EventArgs e)
        {

        }
        //Grupo 3
        
        protected void gvGerGrupo_PageIndexChanging_2(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGrupoGer_PageIndexChanging_2(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGerGrupo_DataBound_2(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Grupo: Item 9 invisível
                int showingGrupo = Int32.Parse(ddlShowingGrupo_2.SelectedValue);
                if (Int32.Parse(e.Row.Cells[9].Text) != showingGrupo)
                    e.Row.Visible = false;
                else
                {
                    //Data: Item 10 invisível
                    DateTime dataHora = DateTime.Parse(e.Row.Cells[10].Text);
                    if (DateTime.Compare(DateTime.Parse(txtCalendario.Text), DateTime.Parse(dataHora.ToString("yyyy/MM/dd"))) != 0)
                        e.Row.Visible = false;
                    else
                    {
                        //Turno: Item 11 invisível
                        if (Int32.Parse(e.Row.Cells[11].Text) != Int32.Parse(cmbTurno.SelectedValue))
                            e.Row.Visible = false;
                        else
                        {
                            //Horário: Item 0
                            e.Row.Cells[0].Text = dataHora.ToString("HH:mm");

                            //Idioma: Item 3
                            Idioma i = new Idioma();
                            i.Id = int.Parse(e.Row.Cells[3].Text);
                            Idioma.Repository.Get(i);
                            e.Row.Cells[3].Text = i.Descricao;

                            //Privativo: Item 4
                            bool pvd = bool.Parse(e.Row.Cells[4].Text);
                            if (pvd)
                            {
                                e.Row.Cells[4].Text = "S";
                                e.Row.ForeColor = System.Drawing.Color.White;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                            else
                                e.Row.Cells[4].Text = String.Empty;

                            //NO: Item 5
                            bool NO = bool.Parse(e.Row.Cells[5].Text);
                            if (NO)
                                e.Row.Cells[5].Text = "S";
                            else
                                e.Row.Cells[5].Text = String.Empty;

                            //Hotel: Item 6
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
        }
        protected void btnEviar_Click_2(object sender, EventArgs e)
        {

        }

        protected void btnEncerrar_Click_2(object sender, EventArgs e)
        {

        }
       
        //Grupo 4
       
        protected void gvGerGrupo_PageIndexChanging_3(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGrupoGer_PageIndexChanging_3(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGerGrupo_DataBound_3(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Grupo: Item 9 invisível
                int showingGrupo = Int32.Parse(ddlShowingGrupo_3.SelectedValue);
                if (Int32.Parse(e.Row.Cells[9].Text) != showingGrupo)
                    e.Row.Visible = false;
                else
                {
                    //Data: Item 10 invisível
                    DateTime dataHora = DateTime.Parse(e.Row.Cells[10].Text);
                    if (DateTime.Compare(DateTime.Parse(txtCalendario.Text), DateTime.Parse(dataHora.ToString("yyyy/MM/dd"))) != 0)
                        e.Row.Visible = false;
                    else
                    {
                        //Turno: Item 11 invisível
                        if (Int32.Parse(e.Row.Cells[11].Text) != Int32.Parse(cmbTurno.SelectedValue))
                            e.Row.Visible = false;
                        else
                        {
                            //Horário: Item 0
                            e.Row.Cells[0].Text = dataHora.ToString("HH:mm");

                            //Idioma: Item 3
                            Idioma i = new Idioma();
                            i.Id = int.Parse(e.Row.Cells[3].Text);
                            Idioma.Repository.Get(i);
                            e.Row.Cells[3].Text = i.Descricao;

                            //Privativo: Item 4
                            bool pvd = bool.Parse(e.Row.Cells[4].Text);
                            if (pvd)
                            {
                                e.Row.Cells[4].Text = "S";
                                e.Row.ForeColor = System.Drawing.Color.White;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                            else
                                e.Row.Cells[4].Text = String.Empty;

                            //NO: Item 5
                            bool NO = bool.Parse(e.Row.Cells[5].Text);
                            if (NO)
                                e.Row.Cells[5].Text = "S";
                            else
                                e.Row.Cells[5].Text = String.Empty;

                            //Hotel: Item 6
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
        }
        protected void btnEviar_Click_3(object sender, EventArgs e)
        {

        }

        protected void btnEncerrar_Click_3(object sender, EventArgs e)
        {

        }

        //Grupo 5
       
        protected void gvGerGrupo_PageIndexChanging_4(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGrupoGer_PageIndexChanging_4(object sender, GridViewPageEventArgs e)
        {

        }

        protected void gvGerGrupo_DataBound_4(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Grupo: Item 9 invisível
                int showingGrupo = Int32.Parse(ddlShowingGrupo_4.SelectedValue);
                if (Int32.Parse(e.Row.Cells[9].Text) != showingGrupo)
                    e.Row.Visible = false;
                else
                {
                    //Data: Item 10 invisível
                    DateTime dataHora = DateTime.Parse(e.Row.Cells[10].Text);
                    if (DateTime.Compare(DateTime.Parse(txtCalendario.Text), DateTime.Parse(dataHora.ToString("yyyy/MM/dd"))) != 0)
                        e.Row.Visible = false;
                    else
                    {
                        //Turno: Item 11 invisível
                        if (Int32.Parse(e.Row.Cells[11].Text) != Int32.Parse(cmbTurno.SelectedValue))
                            e.Row.Visible = false;
                        else
                        {
                            //Horário: Item 0
                            e.Row.Cells[0].Text = dataHora.ToString("HH:mm");

                            //Idioma: Item 3
                            Idioma i = new Idioma();
                            i.Id = int.Parse(e.Row.Cells[3].Text);
                            Idioma.Repository.Get(i);
                            e.Row.Cells[3].Text = i.Descricao;

                            //Privativo: Item 4
                            bool pvd = bool.Parse(e.Row.Cells[4].Text);
                            if (pvd)
                            {
                                e.Row.Cells[4].Text = "S";
                                e.Row.ForeColor = System.Drawing.Color.White;
                                e.Row.BackColor = System.Drawing.Color.Red;
                            }
                            else
                                e.Row.Cells[4].Text = String.Empty;

                            //NO: Item 5
                            bool NO = bool.Parse(e.Row.Cells[5].Text);
                            if (NO)
                                e.Row.Cells[5].Text = "S";
                            else
                                e.Row.Cells[5].Text = String.Empty;

                            //Hotel: Item 6
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
        }

        protected void btnEviar_Click_4(object sender, EventArgs e)
        {

        }

        protected void btnEncerrar_Click_4(object sender, EventArgs e)
        {

        }

        //Grupo 6
        
        //Grupo 7

        //fim da nova informação

    }
}