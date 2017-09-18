<%@ Page Language="C#"  AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="UI.Web.Usuarios" MasterPageFile="Site.Master" EnableSessionState="True" %>

<asp:Content ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div >
        <asp:Panel ID="gridPanel" runat="server">
            <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
            SelectedRowStyle-BackColor="Black"
            SelectedRowStyle-ForeColor="White" 
            DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged" 
            CssClass="GridView" CellPadding="4" ForeColor="#333333" GridLines="None">
                <RowStyle BackColor="#E3EAEB" />
                <Columns>
                    <asp:BoundField DataField="IDPersona" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="NombreUsuario" HeaderText="Usuario" />
                    <asp:BoundField DataField="Habilitado" HeaderText="Habilitado" />
                    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
                </Columns>
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True" />
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
      
        <asp:Panel ID="formPanel" Visible="false" runat="server" CssClass="formPanel">

            <table >
                <tr>
                    <td >
                        Campos obligatorios*</td>
                    <td >
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPersona" runat="server" Text="Persona: " />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPersona" runat="server" 
                            onselectedindexchanged="ddlPersona_SelectedIndexChanged" AutoPostBack="true" 
                            onload="ddlPersona_Load">
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="nombreLabel" runat="server" Text="Nombre: " />
                        </td>
                    <td>
                        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfdNombre" runat="server" 
                            ControlToValidate="txtNombre" Display="Dynamic" 
                            ErrorMessage="El nombre no puede estar vacio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="apellidoLabel" runat="server" Text="Apellido: " />
                        </td>
                    <td >
                        <asp:TextBox ID="txtApellido" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvApellido" runat="server" 
                            ControlToValidate="txtApellido" Display="Dynamic" 
                            ErrorMessage="El apellido no puede estar vacio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="emailLabel" runat="server" Text="Email: " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtEmail" runat="server" />
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="revMail" runat="server" 
                            ControlToValidate="txtEmail" Display="Dynamic" 
                            ErrorMessage="El email no tiene el formato correcto" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="habilitadoLabel" runat="server" Text="Habilitado: " />
                    </td>
                    <td >
                        <asp:CheckBox ID="chbHabilitado" runat="server" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="nombreUsuarioLabel" runat="server" Text="NombreUsuario: " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtNombreUsuario" runat="server" />
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfdNombreUsuario" runat="server" 
                            ControlToValidate="txtNombreUsuario" Display="Dynamic" 
                            ErrorMessage="El nombre de usuario no puede estar vacio">*</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="claveUsuarioLabel" runat="server" Text="Clave: " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtClave" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="repetirClaveLabel" runat="server" Text="RepetirClave: " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtRepetirClave" runat="server" TextMode="Password" />
                    </td>
                    <td>
                        <asp:CompareValidator ID="cpvClave" runat="server" ControlToCompare="txtClave" 
                            ControlToValidate="txtRepetirClave" Display="Dynamic" 
                            ErrorMessage="Las claves no coinciden">*</asp:CompareValidator>
                    </td>
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
