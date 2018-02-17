<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Especialidades.aspx.cs" Inherits="UI.Web.Especialidades" EnableSessionState="True" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor = "Black"
    SelectedRowStyle-ForeColor = "White"
    DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged1" 
        CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="GridView">
    
    <Columns>
    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
    <asp:CommandField SelectText="Seleccionar" ShowSelectButton="true" />
    </Columns>
    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />

<SelectedRowStyle BackColor="#C5BBAF" ForeColor="#333333" Font-Bold="True"></SelectedRowStyle>
    <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
    <EditRowStyle BackColor="#7C6F57" />
    </asp:GridView>
        <asp:Panel ID="gridActionsPanel" runat="server">
            <asp:LinkButton ID="editarLinkButton" runat="server" OnClick="editarLinkButton_Click">Editar</asp:LinkButton>
            <asp:LinkButton ID="eliminarLinkButton" runat="server" 
                onclick="eliminarLinkButton_Click">Eliminar</asp:LinkButton>
            <asp:LinkButton ID="nuevoLinkButton" runat="server" 
                onclick="nuevoLinkButton_Click">Nuevo</asp:LinkButton>
        </asp:Panel>
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <table >
                <tr>
                    <td>
                        &nbsp;</td>
                    <td >
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="descripcionLabel" runat="server" Text="Descripción" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDescripcion"
                        Display="None"
                        ErrorMessage="El campo no puede estar vacío"
                        ForeColor="Red">
                        </asp:RequiredFieldValidator>
                    
                        </td>
                    <td >
                        </td>
                </tr>
                <tr>
                    <td style="width: 141px">
                        &nbsp;</td>
                    <td style="width: 159px">
                        &nbsp;</td>
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
                onclientclick="Response.Redirect(~/Especialidades.aspx)" />
        </asp:Panel>

</asp:Content>
