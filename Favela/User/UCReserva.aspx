<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="UCReserva.aspx.cs" Inherits="Favela.User.UCReserva" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .hiddencol { 
            display: none;
        }
        .style10 {
            width: 884px;
        }

        .style15 {
            width: 83px;
        }

        .style24 {
            width: 62px;
        }

        .style28 {
            width: 189px;
        }

        .style31 {
            width: 28px;
        }

        .style32 {
            width: 1px;
        }

        .style35 {
            width: 59px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Filtro Data/Turno</h2>
    <table border="0" cellspacing="0" cellpadding="3" style="width: 250px">
        <tbody>
            <tr>
                <td style="width: auto">
                    <h4>
                        <asp:LinkButton ID="LBCalendario" Text="Data do Passeio"
                             OnClick="LBCalendario_Click" runat="server" />
                        <asp:Calendar ID="cldCalendario" Text="Calendário" runat="server" 
                            Visible="false" OnSelectionChanged="cldCalendario_Click" />
                        <asp:TextBox ID="txtCalendario" Width="70px" runat="server" 
                            Visible="true" Enabled="false"></asp:TextBox>
                        <asp:TextBox ID="txtDataAnterior" Width="70px" runat="server" 
                            Visible="false" Enabled="false"></asp:TextBox>
                    </h4>
                    <asp:Label ID="Calendario1" runat="server" />

                </td>
                <td align="left"><br /> <asp:Button runat="server" ID="btnHoje" OnClick="btnHoje_Click" Text="Hoje" /></td>
                <td align="left" class="style15">
                    <h4>Turno</h4>
                    <asp:DropDownList runat="server" ID="cmbTurno" name="Turno" Style="width: 85px">
                        <asp:ListItem Value="1">Manhã</asp:ListItem>
                        <asp:ListItem Value="2">Tarde</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </tbody>
    </table>
    <h2>Cadastrar pré-Reserva</h2>
    <table width="914" border="1" align="center" cellpadding="8" cellspacing="0" bgcolor="#FFFFFF">
        <table>
            <%--<td align="left" class="style15">
                <h4>Idioma</h4>
                <asp:DropDownList ID="cmbIdioma" name="Idioma" runat="server">
                </asp:DropDownList>
            </td>
            <td align="left" class="style15">
                <h4>Privado</h4>
                <asp:CheckBox ID="ckbPrivado" runat="server" />
            </td>--%>
        </table>
        <table border="0" cellspacing="0" cellpadding="5" style="width: 914px">
            <tbody>
                <tr>
                    <td align="left" class="style24">
                        <h4>Horário</h4>
                        <asp:TextBox runat="server" ID="txtHorario" autocomplete="on" type="cadastro" name="horario" size="10"
                            Style="width: 50px" />
                    </td>
                    
                    <td align="left" class="style31">
                        <h3>Nº<br />
                            <asp:TextBox runat="server" ID="txtQuantidade" type="cadastro" name="quantidade" size="2" Style="width: 20px" />
                    </td>
                    <td align="left" class="style28">
                        <h3>Nome/País<br />
                            <asp:TextBox runat="server" ID="txtCliente" align="center" type="cadastro"
                                name="nCliente" size="10" Width="165px" />
                    </td>

                    <td align="left" class="style32">
                        <h3>NO<br />
                            <asp:CheckBox runat="server" ID="ckbNoHotel" name="sim" AutoPostBack="true" value="sim" OnCheckedChanged="ckbNoHotel_CheckedChanged" Checked="true" />
                    </td>
                    <td colspan="2" align="left">
                        <h3>Hotel<br />
                            <asp:DropDownList ID="cmbHotel" name="hotel" Style="width: 200px" runat="Server">
                                <asp:ListItem Value="0" Text=" " Selected></asp:ListItem>
                            </asp:DropDownList>
                    </td>
                    <td align="left" class="style35">
                        <h3>Apt<br />
                            <asp:TextBox runat="server" Enabled="false" type="cadastro" ID="txtApto"
                                name="nApto" size="3" Width="41px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3>Grupo<br />
                            <asp:DropDownList ID="ddlGrupo" name="grupo" Style="width: 40px" runat="Server">
                                <asp:ListItem Value="0" Text="Selecione o grupo..." Selected></asp:ListItem>
                                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            </asp:DropDownList>
                    </td>
                    <td align="left" class="style15">
                        <h4>Idioma</h4>
                        <asp:DropDownList ID="cmbIdioma" name="Idioma" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        <h3>Origem|Preço|Contato<br />
                            <asp:TextBox TextMode="MultiLine" runat="server" ID="txtInfo" type="cadastro" name="mais_info"
                                size="35" Height="35px" Width="165px" />
                    </td>
                    <td align="left" class="style15">
                        <h4>Privado</h4>
                        <asp:CheckBox ID="ckbPrivado" runat="server" />
                    </td>
                </tr>
                <%--<tr>
                        <td align="left" class="style20"><h3>E-mail<br/>
                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtEmail" autocomplete="on" type="cadastro" name="email" size="50" 
                            style="width: 200px"/>
                            </td>
                    </tr>--%>
                <tr>
                    <td colspan="8" align="center">
                        <asp:TextBox runat="server" ID="hdnId" Visible="false"></asp:TextBox>
                        <asp:Button runat="server" ID="btnConfirmaAlterar" CommandName="altera" type="button" OnClick="btnInserir_Click" Text="Confirmar" Visible="false" />
                        <asp:Button runat="server" ID="btnCancelar" CommandName="cancela" type="button" OnClick="btnInserir_Click" Text="Cancelar" Visible="false" />
                        <asp:Button runat="server" ID="btnInserir" CommandName="insere" type="button" OnClick="btnInserir_Click" Text="Inserir" /></td>
                    <br />
                </tr>
            </tbody>
        </table>
    </table>
    <br />
    <h2>Grupo 
        <asp:DropDownList ID="ddlShowingGrupo" name="grupo" runat="Server" Width="40" AutoPostBack="true">
                                <asp:ListItem Value="1" Text="1" Selected></asp:ListItem>
                                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                <asp:ListItem Value="6" Text="6"></asp:ListItem>
                                <asp:ListItem Value="7" Text="7"></asp:ListItem>
                                <asp:ListItem Value="8" Text="8"></asp:ListItem>
                            </asp:DropDownList></h2>

    <%--Inserir Filtros de pesquisa Cliente, Turno e Dia--%>
    <table width="895" border="1" align="center" cellpadding="5" cellspacing="0" bgcolor="#FFFFFF">
        <td valign="top" class="style10">
            <table border="0" cellspacing="0" cellpadding="10" style="width: 874px; margin-bottom: 0px;">
                <tbody>
                    <tr id="idGridGerGrupo" visible="true" runat="server">
                        <td colspan="2">
                            <asp:GridView ID="gvGerGrupo" runat="server" DataKeyNames="Id" BoderColor="#4B4D4C" CellPadding="2" GridLines="None"
                                BorderWidth="1px" CellSpacing="1" Width="100%" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="gvGerGrupo_PageIndexChanging"
                                Font-Size="10pt" PageSize="10" EmptyDataText="Nenhuma reserva cadastrada" OnRowDataBound="gvGerGrupo_DataBound">
                                <RowStyle BackColor="#CDC5BF" ForeColor="#5C5C5C" />
                                <HeaderStyle BackColor="#CDC5BF" Font-Bold="true" ForeColor="White" />
                                <AlternatingRowStyle BackColor="#F1EFD8" />
                                <Columns>
                                    <asp:BoundField HeaderText="Horário" DataField="DataHora">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="5px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nº" DataField="Quantidade">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="5px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Nome/País" DataField="NomeCliente">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="25px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Idioma" DataField="IdIdioma">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Pvd" DataField="Privativo">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="NO" DataField="NoHotel">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Hotel" DataField="IdHotel">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="15px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Apt" DataField="Apartamento">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="5px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Origem Preço Contato" DataField="OrigemPrecoContato">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="110px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Grupo" DataField="Grupo" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="5px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Data" DataField="DataHora" HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="5px" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Ação">
                                        <HeaderStyle BackColor="#5c5c5c" Font-Bold="true" ForeColor="White" Width="30px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Button ID="btnAlterar" runat="server" CommandArgument='<%# Bind("Id")%>' Enabled="false" AutoPostBack="true" Text="Alterar" OnClick="btnAlterar_onClick"></asp:Button>
                                            <asp:Button ID="btnExcluir" runat="server" CommandArgument='<%# Bind("Id")%>' Enabled="false" AutoPostBack="true" Text="Excluir" OnClick="btnExcluir_onClick"></asp:Button>
                                            <%--<asp:CheckBox class="checkIncluir" AutoPostBack="true" OnCheckedChanged="chkIncluir_CheckedChanged" ID="chkIncluir" runat="server" Text="Incluir"></asp:CheckBox>--%>
                                        </ItemTemplate>
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
                                <%--<asp:Button runat="server" ID="btnGerarGrupo" Text="Gerar Grupo" OnClick="btnGerarGrupo_Click"/>--%>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
    </table>
    <br />


</asp:Content>

