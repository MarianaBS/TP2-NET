<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DocentesCursos.aspx.cs" Inherits="UI.Web.docentes_cursos" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div>
<asp:Panel ID="gridPanel" runat="server">
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor="Black"
    SelectedRowStyle-ForeColor="White"
    DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
        CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="GridView">
        
    <Columns>
        <asp:BoundField HeaderText="IDCurso" DataField="IDCurso"/>
        <asp:BoundField HeaderText="IDDocente" DataField="IDDocente" />
        <asp:BoundField HeaderText="Cargo" DataField="TiposCargo" />
        <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />            
    </Columns>
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#7C6F57" />
       
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
    <asp:ValidationSummary ID="ValidationSummary1"  runat="server" DisplayMode="BulletList"/>
</asp:Panel>

<asp:Panel ID="formPanel" Visible="false" runat="server">
    <table>
        
        <tr>
            <td >
                <asp:Label ID="lblIDCurso" runat="server" Text="IDCurso" />
            </td>
            <td >
                <asp:DropDownList ID="ddlCurso" runat="server" Height="22px" Width="128px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
            <tr>
                <td>
                    <asp:Label ID="lblIDDocente" runat="server" Text="IDDocente" />
                </td>
                <td>
                    <asp:DropDownList ID="ddlDocente" runat="server" Height="22px" 
                        onload="ddlDocente_Load" 
                        onselectedindexchanged="ddlDocente_SelectedIndexChanged" Width="128px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDocente" runat="server" Text="Docente"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtDocente" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
        <tr>
            <td >
                <asp:Label ID="lblTipoCargo" runat="server" Text="TipoCargo" />
            </td>
            <td >
                <asp:DropDownList ID="ddlTipoCargo" runat="server" Height="22px"
                      Width="128px">
                    
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
        onclientclick="Response.Redirect(~/Usuarios.aspx)" />
</asp:Panel>
</div>
</asp:Content>
