<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Materias.aspx.cs" Inherits="UI.Web.Materias" EnableSessionState="True" %>

<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
<asp:Panel ID="gridPanel" runat="server" >
    <asp:GridView ID="gridView" runat="server" AutoGenerateColumns="False"
    SelectedRowStyle-BackColor = "Black"
    SelectedRowStyle-ForeColor = "White"
    DataKeyNames="ID" onselectedindexchanged="gridView_SelectedIndexChanged1" 
        CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="GridView">
        
    <Columns>
    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
    <asp:BoundField HeaderText="Hs.Semanales" DataField="HSSemanales" />
    <asp:BoundField HeaderText="Hs.Totales" DataField="HSTotales" />
    <asp:BoundField HeaderText="IdPlan" DataField="IdPlan" />
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
        <asp:Panel ID="formPanel" Visible="false" runat="server">
            <table >
                
                <tr>
                    <td >
                        <asp:Label ID="descripcionLabel" runat="server" Text="Descripción" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"
                        ControlToValidate="txtDescripcion"
                        Display="None"
                        ErrorMessage="El campo Descripción no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    
                        </td>
                   
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="hssemanalesLabel" runat="server" Text="Hs.Semanales " />
                    </td>
                    <td >
                        <asp:TextBox ID="txtHSSemanales" runat="server" />
                         <asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server"
                        ControlToValidate="txtHSSemanales"
                        Display="None"
                        ErrorMessage="El campo Hs Semanales no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    
                        </td>
                    
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="HSTotalesLabel" runat="server" Text="Hs.Totales" />
                    </td>
                    <td >
                        <asp:TextBox ID="txtHSTotales" runat="server" />
                        <asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server"
                        ControlToValidate="txtHSTotales"
                        Display="None"
                        ErrorMessage="El campo Hs Totales no puede estar vacío"
                        ForeColor="Red">
                    </asp:RequiredFieldValidator>
                    </td>
                   
                </tr>
                <tr>
                    <td >
                        <asp:Label ID="IdPlanLabel" runat="server" Text="IDPlan" />
                    </td>
                    <td >
                        <asp:DropDownList ID="ddlPlan" runat="server" Height="19px" Width="127px">
                        </asp:DropDownList>
                    </td>
                    
                </tr>
            </table>
        </asp:Panel> 
              
        <asp:Panel ID="formActionsPanel" runat="server" Visible="false">
        <asp:Button ID="btnAceptar"   Text="Aceptar" runat="server" Visible="true" 
                onclick="btnAceptar_Click"/> 
        <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" Visible="true" 
                onclick="btnCancelar_Click" 
                onclientclick="Response.Redirect(~/Materia.aspx)" />
        </asp:Panel>
</asp:Content>
