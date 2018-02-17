<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Cursos.aspx.cs" Inherits="UI.Web.Cursos" MasterPageFile="Site.Master" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server" >
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor = "Black"
    SelectedRowStyle-ForeColor = "White"
    DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
        CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="GridView">
        <RowStyle BackColor="#E3EAEB" />
    <Columns>
    <asp:BoundField HeaderText="Año Calendario" DataField="AnioCalendario" />
    <asp:BoundField HeaderText="Cupo" DataField="Cupo" />
    <asp:BoundField HeaderText="IDComisión" DataField="IDComision" />
    <asp:BoundField HeaderText="IDMateria" DataField="IDMateria" />
    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
    </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</asp:Panel>

<asp:Panel ID="gridActionsPanel" runat="server">
    <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
    <asp:LinkButton ID="eliminarLinkButton" runat="server" Onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" Onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>

<asp:Panel ID="panelValidators" runat="server" Visible="True">
    <asp:ValidationSummary ID="ValidationSummary1"  runat="server" DisplayMode="BulletList"/>
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <table>
       
        <tr>
            <td >
                <asp:Label ID="lblAnioCalendario" runat="server" Text="Año calendario"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAnioCalendario" runat="server" Width="168px" Height="22px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtAnioCalendario"
                        Display="None"
                        ErrorMessage="El campo Año no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label2" runat="server" Text="Cupo"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtCupo" runat="server" Width="168px"></asp:TextBox>
                <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtCupo"
                        Display="None"
                        ErrorMessage="El campo Cupo no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label3" runat="server" Text="Comisión"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlComision" runat="server" Height="22px" Width="168px">
                </asp:DropDownList>
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="IDMateria"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddlMateria" runat="server" Height="22px" Width="168px" 
                    AutoPostBack="True" onload="ddlMateria_Load" 
                    onselectedindexchanged="ddlMateria_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="Label4" runat="server" Text="Materia"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMateria" runat="server" Width="168px" Enabled="false"></asp:TextBox>
                </td>
        </tr>
    </table>

</asp:Panel>

<asp:Panel ID="formActionsPanel" runat="server" Visible="false">
    <asp:Button ID="btnAceptar"   Text="Aceptar" runat="server" Visible="true" 
                onclick="btnAceptar_Click"/> 
    <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" Visible="true" 
                onclick="btnCancelar_Click" 
                onclientclick="Response.Redirect(~/Cursos.aspx)" />
</asp:Panel>

</asp:Content>
