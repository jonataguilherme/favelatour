<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UCGrupos.aspx.cs" Inherits="Favela.User.UCGrupos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style2 {
            width: 142px;
        }

        .style7 {
            width: 825px;
        }

        .style10 {
            width: 884px;
        }

        .style15 {
            width: 83px;
        }

        .style17 {
            width: 214px;
        }

        .style18 {
            width: 86px;
        }

        .style19 {
            width: 84px;
        }

        .style20 {
            width: 209px;
        }

        .style21 {
            width: 55px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

     <h2>Grupos </h2>

    <h2>Gerador de Grupos </h2>
   
        <%--Inserir Filtros de pesquisa turno e dia--%>
    
    <table width="895" border="1" align="center" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
        <td valign="top" class="style10">
            <table border="0" cellspacing="0" cellpadding="10" style="width: 874px; margin-bottom: 0px;">
                <tbody>
                    <tr>
                        <td></td>
                    </tr>
                    <tr id="idGridGerGrupo" visible="true" runat="server">
                        <td colspan="2">
                            <asp:GridView ID="gvGerGrupo" runat="server" DataKeyNames="Id" BoderColor="#4B4D4C" CellPadding="2" GridLines="None"
                                BorderWidth="1px" CellSpacing="1" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvGerGrupo_PageIndexChanging"
                                Font-Size="10pt" PageSize="5" EmptyDataText="Nenhuma reserva cadastrada" OnRowDataBound="gvGerGrupo_DataBound">
                                <RowStyle BackColor="#CDC5BF" ForeColor="#5C5C5C" />
                                <HeaderStyle BackColor="#CDC5BF" Font-Bold="true" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#F1EFD8" />
                                <Columns>
                                    <asp:BoundField HeaderText="Horário" DataField="DataHora">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nome do Cliente" DataField="NomeCliente">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="125px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Idioma" DataField="IdIdioma">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="25px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nº" DataField="Quantidade">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hotel" DataField="IdHotel" NullDisplayText="Não Cadastrado">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="100px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Ação">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="20px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox class="checkIncluir" AutoPostBack="true" OnCheckedChanged="chkIncluir_CheckedChanged" ID="chkIncluir" runat="server" Text="Incluir"></asp:CheckBox>
                                            <asp:Label Text='<%# Bind("Id")%>' runat="server" ID="lblID" style="display:none"></asp:Label>
                                       <%--     <asp:Button ID="btnAlterar" runat="server" CommandArgument='<%# Bind("Id")%>' Enabled="false" AutoPostBack="true" Text="Alterar" OnClick="btnAlterar_onClick"></asp:Button><br />
                                            <asp:Button ID="btnExcluir" runat="server" CommandArgument='<%# Bind("Id")%>' Enabled="false" AutoPostBack="true" Text="Excluir" OnClick="btnExcluir_onClick"></asp:Button>
                                      --%>  </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            <div style="float: right">
                                 <asp:DropDownList ID="cmbGuia" name="hotel" Style="width: 304px" runat="Server">
                                <asp:ListItem Value="0">Selecione o guia</asp:ListItem>
                                   </asp:DropDownList>
                                
                                 <asp:DropDownList ID="cmbMotorista" name="hotel" Style="width: 304px" runat="Server">
                                <asp:ListItem Value="0">Selecione o motorista</asp:ListItem>
                                   </asp:DropDownList>
                                <asp:Button runat="server" ID="btnGerarGrupo" Text="Gerar Grupo" OnClick="btnGerarGrupo_Click"/>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
    </table>
    <br />
    <h2>Grupos Cadastrados</h2>
    <table width="895" border="1" align="center" cellpadding="6" cellspacing="0" bgcolor="#FFFFFF">
        <td valign="top" class="style7">
            <%--Inserir filtros de pesquisa turno e dia--%>
            <table border="0" cellspacing="0" cellpadding="6" style="width: 872px">
                <tbody>
                    <tr id="idGridGrupoGer" visible="true" runat="server">
                        <td colspan="2">
                            <asp:GridView ID="gvGrupoGer" runat="server" DataKeyNames="IdGrupo" BoderColor="#4B4D4C" CellPadding="2" GridLines="None"
                                BorderWidth="1px" CellSpacing="1" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvGrupoGer_PageIndexChanging"
                                Font-Size="10pt" PageSize="5" EmptyDataText="Nenhum grupo cadastrado" OnRowDataBound="gvGrupoGer_DataBound">
                                <RowStyle BackColor="#CDC5BF" ForeColor="#5C5C5C" />
                                <HeaderStyle BackColor="#CDC5BF" Font-Bold="true" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#F1EFD8" />
                                <Columns>
                                    <asp:BoundField HeaderText="Horário" DataField="horario">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Motorista" DataField="matriculaMotorista">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Guia" DataField="matriculaGuia">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Qtd" DataField="quantidade">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="10px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Ação">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="20px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnAlterar" runat="server" CommandArgument='<%# Bind("IdGrupo")%>' Enabled="false" AutoPostBack="true" Text="Alterar" OnClick="btnAlterar_onClick"></asp:Button><br />
                                            <asp:Button ID="btnExcluir" runat="server" CommandArgument='<%# Bind("IdGrupo")%>' Enabled="false" AutoPostBack="true" Text="Excluir" OnClick="btnExcluir_onClick"></asp:Button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
    </table>
</asp:Content>
