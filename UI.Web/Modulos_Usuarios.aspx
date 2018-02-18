<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Modulos_Usuarios.aspx.cs" Inherits="UI.Web.Modulos_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<div>
    <asp:Panel ID="gridPanel" runat="server">
        <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
        SelectedRowStyle-BackColor="Black"
        SelectedRowStyle-ForeColor="White"
        DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
            CellPadding="4" ForeColor="#333333" GridLines="Both">
            <RowStyle 
            CssClass="GridView" />
        <Columns>
            <asp:BoundField HeaderText="IDUsuario" DataField="IdUsuario" />
            <asp:BoundField HeaderText="IDModulo" DataField="IdModulo" />
            <asp:CheckBoxField HeaderText="PermiteAlta" DataField="PermiteAlta" />
            <asp:CheckBoxField HeaderText="PermiteBaja" DataField="PermiteBaja" />
            <asp:CheckBoxField HeaderText="PermiteModificación " DataField="PermiteModificacion" />
            <asp:CheckBoxField HeaderText="PermiteConsulta" DataField="PermiteConsulta" />
            <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />            
        </Columns>
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
             <SelectedRowStyle BackColor="#89bcba" ForeColor="#333333" />
            <HeaderStyle BackColor="#1C5E55"  ForeColor="White" />
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
                    <asp:Label ID="Label1" runat="server" Text="IDUsuario"></asp:Label>
                </td>
                <td style="width: 128px" >
                    <asp:DropDownList ID="ddlUsuario" runat="server" AutoPostBack="True" 
                        Height="18px" onload="ddlUsuario_Load" 
                        onselectedindexchanged="ddlUsuario_SelectedIndexChanged" Width="123px">
                    </asp:DropDownList>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblUsuario" runat="server" Text="Nombre y Apellido" />
                </td>
                <td style="width: 128px" >
                    <asp:TextBox ID="txtApyNom" runat="server" Enabled="False"></asp:TextBox>
                    </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblModulo" runat="server" Text="IDMódulo" />
                </td>
                <td style="width: 128px">
                    <asp:DropDownList ID="ddlModulo" runat="server" AutoPostBack="True" 
                        Height="16px" onload="ddlModulo_Load" 
                        onselectedindexchanged="ddlModulo_SelectedIndexChanged" Width="124px">
                    </asp:DropDownList>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
                </td>
                <td style="width: 128px">
                    <asp:TextBox ID="txtDescripcionModulo" runat="server" Enabled="False"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblAlta" runat="server" Text="PermiteAlta" />
                </td>
                <td style="width: 128px" >
                    <asp:CheckBox ID="chbAlta" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblBaja" runat="server" Text="PermiteBaja " />
                </td>
                <td style="width: 128px" >
                    <asp:CheckBox ID="chbBaja" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="clblModificacion" runat="server" Text="PermiteModificación " />
                </td>
                <td style="width: 128px" >
                    <asp:CheckBox ID="chbModifcado" runat="server" />
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td >
                    <asp:Label ID="lblConsulta" runat="server" Text="PermiteConsulta" />
                </td>
                <td style="width: 128px" >
                    <asp:CheckBox ID="chbConsulta" runat="server" />
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
