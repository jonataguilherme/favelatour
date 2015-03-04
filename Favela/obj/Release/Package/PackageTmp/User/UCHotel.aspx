<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UCHotel.aspx.cs" Inherits="Favela.User.UCHotel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 226px;
        }
        .style2
        {
            width: 85px;
        }
        .style3
        {
            width: 94px;
        }
        .style4
        {
            width: 675px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <h2>Hotel
    </h2>
    <table >
        <tbody>
            <tr>
            <td class="style1"></td>
                <td align="left" colspan="1" class="style2"><h3>Novo hotel</h3>
                    <form>
                        <asp:TextBox runat="server" AutoPostBack="true" ID="txtHotel" type="cadastro" name="nome_hotel" size="50"/>
                    </form>
                </td>
             </tr>
            </ tbody> 
         </ table>
         
         <table>
           <tbody>
              <tr>
                <td colspan="2" align="center" class="style4"> 
                <input name="bntConfirma" type="button" value="Confirmar" />
                    <br/>
                 </td>
               </tr>                     
          </tbody>
      </table>
      <h2>Hotéis Cadastrados</h2>
    <table width="450" border="1" align="center" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
    <td width="450" valign="top">
        <table border="0" cellspacing="0" cellpadding="10" style="width: 450px">
            <tbody>
                <tr>
                    <td colspan="2" align="center"><h3>Pesquisar</h3> &nbsp;&nbsp;
                    <input type="pesquisa" size="35" style="width: 300px; margin-left: 30px" />
                    <input name="bntBuscar" type="button" value="Buscar" /> 
                    </td>
                </tr>
                <tr id="idGridHotGrupo" visible="true" runat="server">                
                    <td colspan="2" class="style6">
                        <asp:GridView ID="gvHotGrupo" runat="server" DataKeyNames="Id" 
                            BoderColor="#4B4D4C" CellPadding="2" GridLines="None"
                BorderWidth="1px" CellSpacing="1" Width="100%" AutoGenerateColumns="false" 
                            AllowPaging="true" OnPageIndexChanging="gvHotGrupo_PageIndexChanging"
                Font-Size="10pt" PageSize="5" Height="196px">
                    <RowStyle BackColor="#CDC5BF" ForeColor="#5C5C5C" />
                    <HeaderStyle BackColor="#CDC5BF" Font-Bold="true" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#F1EFD8" />
                    <Columns>
                        <asp:BoundField HeaderText="Nome do Hotel" DataField="HotelGrid">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="165px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ação">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="110px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                        <asp:CheckBox Id="CheckBox2" runat="server" AutoPostBack="True" OnCkeckedChanged="ckbAlt_CheckChanged" Text="Alterar"></asp:CheckBox>
                                        <asp:CheckBox Id="CheckBox1" runat="server" AutoPostBack="True" OnCkeckedChanged="ckbExcluir_CheckChanged" Text="Excluir"></asp:CheckBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
                </tr>
            </tbody>
      </table>
</asp:Content>
