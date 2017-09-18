<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Inherits="UI.Web.Personas" EnableSessionState="True"%>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

<asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor="Black"
    SelectedRowStyle-ForeColor="White" Width=500px
    DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
    CellPadding="4" ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#E3EAEB" />
    <Columns>
        <asp:BoundField HeaderText="Plan" DataField="IdPlan" />
        <asp:BoundField HeaderText="Legajo" DataField="Legajo" />
        <asp:BoundField HeaderText="Tipo" DataField="TipoPersona" />
        <asp:BoundField HeaderText="Apellido" DataField="Apellido" />
        <asp:BoundField HeaderText="Nombre" DataField="Nombre" /> 
        <asp:BoundField HeaderText="Telefono" DataField="Telefono" />
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
    <asp:LinkButton ID="eliminarLinkButton" runat="server" 
        onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
    <asp:LinkButton ID="nuevoLinkButton" runat="server" 
        onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
</asp:Panel>
<asp:Panel ID="panelValidators" runat="server" Visible="True">
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <table>
        <tr>
            <td>
                Campos obligatorios*</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " />
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " />
            </td>
            <td >
                <asp:TextBox ID="txtApellido" runat="server" />
                </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="emailLabel" runat="server" Text="Email: " />
            </td>
            <td >
                <asp:TextBox ID="txtEmail" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="direccionLabel" runat="server" Text="Direccion" />
            </td>
            <td >
                <asp:TextBox ID="txtDireccion" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="fechaNacimientoLabel" runat="server" Text="Fecha de Nacimiento" />
            </td>
            <td >
                <asp:TextBox ID="txtFechaNacimiento" runat="server" />
            </td>
            <td  >
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="legajoLabel" runat="server" Text="Legajo" />
            </td>
            <td >
                <asp:TextBox ID="txtLegajo" runat="server"  />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="telefonoLabel" runat="server" Text="Telefono" />
            </td>
            <td>
                <asp:TextBox ID="txtTelefono" runat="server" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="tipoPersonaLabel" runat="server" Text="Tipo Persona" />
            </td>
            <td >
                <asp:DropDownList ID="ddlTipoPersona" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="idPlanLabel" runat="server" Text="IDPlan" />
            </td>
            <td >
                <asp:DropDownList ID="ddlIdPlan" runat="server">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Panel> 
      
<asp:Panel ID="formActionsPanel" runat="server" Visible="false">
<asp:Button ID="btnAceptar"   Text="Aceptar" runat="server" Visible="true" 
        onclick="btnAceptar_Click"/> 
<asp:Button ID="btnCancelar" Text="Cancelar" runat="server" Visible="true" 
        onclick="btnCancelar_Click" 
        onclientclick="Response.Redirect(~/Persona.aspx)" />
</asp:Panel>

</asp:Content>
