<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlumnosIncripciones.aspx.cs" Inherits="UI.Web.AlumnosIncripciones" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div>
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White"
            DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
                CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="GridView">
                <RowStyle BackColor="#E3EAEB" />
            <Columns>
                <asp:BoundField HeaderText="IDAlumno" DataField="IDAlumno" />
                <asp:BoundField HeaderText="IDCurso" DataField="IDCurso" />
                <asp:BoundField HeaderText="Condición" DataField="Condicion" />
                <asp:BoundField HeaderText="Nota" DataField="Nota" />
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
            <asp:ValidationSummary ID="ValidationSummary1"  runat="server" DisplayMode="BulletList"/>
        </asp:Panel>
        
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <table >
                  <tr>
                    <td>
                        <asp:Label ID="lblAlumno" runat="server" Text="IDAlumno"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlIDAlumno" runat="server" AutoPostBack="True" 
                            Height="22px" onload="ddlIDAlumno_Load" 
                            onselectedindexchanged="ddlIDAlumno_SelectedIndexChanged" Width="128px">
                        </asp:DropDownList>
                        
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblNyAAlumno" runat="server" Text="Nombre y Apellido" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtAlumno" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblCurso" runat="server" Text="IDCurso" />
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
                        <asp:Label ID="lblCondicion" runat="server" Text="Condición" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtCondicion" runat="server" />
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtCondicion"
                        Display="None"
                        ErrorMessage="El campo  Condicion no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="lblNota" runat="server" Text="Nota " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtNota" runat="server" />
                        <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtNota"
                        Display="None"
                        ErrorMessage="El campo Nota no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
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
