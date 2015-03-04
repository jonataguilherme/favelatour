<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UCMotorista.aspx.cs" Inherits="Favela.User.UCMotorista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style2
        {
            height: 52px;
            width: 337px;
        }
        .style3
        {
            width: 337px;
        }
        .style5
        {
            width: 717px;
        }
        .style6
        {
            width: 573px;
        }
        .style7
        {
            width: 259px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Motorista
    </h2>
   <table >
        <tbody>
            <tr>
            <td class="style1"></td>
                <td align="left" colspan="1" class="style2"><h3>
                    Nome</h3>
                    <asp:TextBox runat="server" ID="txtNome" type="cadastro" name="mais_info" size="50" style="width: 178px; margin-top: 0px"/>
                </td>
             </tr>
             <tr>
                <td class="style1"></td>
                <td align="left" colspan="1" class="style3"><h3>
                Telefone</h3>             

                        <asp:TextBox runat="server" ID="txtTel" type="cadastro" name="mais_info" size="50" style="width: 178px; margin-top: 0px"/>
                    
                    <br />
                </td>
              </tr>
            </ tbody> 
         </ table>
         
         <table>
           <tbody>
              <tr>
                <td colspan="2" align="center" class="style4"> 
                <asp:Button runat="server" AutoPostBack="true" ID="btnConfirmar" name="BtnConfirma" type="button" onclick="btnConfirma" text="Confirmar" />
                    <br/>
                 </td>
               </tr>                     
          </tbody>
      </table>
      <h2>Motoristas Cadastrados</h2>
    <table width="450" border="1" align="center" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
    <td width="450" valign="top">
        <table border="0" cellspacing="0" cellpadding="10" style="width: 450px">
            <tbody>
                <tr id="idGridMotGrupo" visible="true" runat="server">
                    <td colspan="2" class="style6">
                        <asp:GridView ID="gvMotGrupo" runat="server" DataKeyNames="Matricula" BoderColor="#4B4D4C" CellPadding="2" GridLines="None"
                BorderWidth="1px" CellSpacing="1" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvMotGrupo_PageIndexChanging"
                Font-Size="10pt" PageSize="5">
                    <RowStyle BackColor="#CDC5BF" ForeColor="#5C5C5C" />
                    <HeaderStyle BackColor="#CDC5BF" Font-Bold="true" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#F1EFD8" />
                    <Columns>
                        <asp:BoundField HeaderText="Nome do Guia" DataField="Nome">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="125px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Telefone" DataField="Telefone">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="45px"/>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Email" DataField="Email">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="155px"/>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" /> 
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Ação">
                            <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="20px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                        <asp:Button Id="btnAlterar" runat="server" CommandArgument='<%# Bind("Matricula")%>' Text="Alterar" Enabled="false"></asp:Button><br />
                                        <asp:Button Id="btnExcluir" runat="server" CommandArgument='<%# Bind("Matricula")%>' Text="Excluir" Enabled="false"></asp:Button>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                </td>
                </tr>
            </tbody>
      </table>
</asp:Content>
