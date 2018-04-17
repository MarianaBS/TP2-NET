<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" MasterPageFile="~/Site.Master" EnableSessionState = "True" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>

         <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema! " Font-Names="Tahoma" style="font-size: x-large"></asp:Label>
            
        <table >
        
        
        <tr>
            <td style="height: 23px; width: 18px;" >
                </td>
            <td style="height: 23px; width: 108px;">
                </td>
        </tr>
        <tr>
            <td style="width: 18px" >
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Font-Names="Tahoma" style="font-size: medium"></asp:Label>
            </td>
            <td style="width: 108px">
                <asp:TextBox ID="txtUsuario" runat="server" BackColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 18px" >
                <asp:Label ID="lblClave" runat="server" Text="Clave" Font-Names="Tahoma" style="font-size: medium"></asp:Label>
            </td>
            <td style="width: 108px">
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password" BackColor="White"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 18px" >
                &nbsp;</td>
            <td style="text-align:right; width: 108px;">
                <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
                    Text="Ingresar" style="width: 72px" Font-Names="Tahoma" BorderStyle="Groove" BackColor="WhiteSmoke" Font-size="Medium" />
            </td>
        </tr>
        </table>
    </div>
    <p>
                <asp:LinkButton ID="lnkRecordarClave" runat="server" 
                    onclick="lnkRecordarClave_Click" Font-Names="Tahoma" style="font-size: medium">Olvidé mi Clave</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblLogin" runat="server" Font-Bold="True" ForeColor="red" Font-Names="Tahoma" style="font-size: medium"></asp:Label>
    </p>
</asp:Content>