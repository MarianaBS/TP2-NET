<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UI.Web.Login" MasterPageFile="~/Site.Master" EnableSessionState = "True" %>


<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">
    <div>
        <table >
        <tr>
            <td>
            </td>
            <td>
                <asp:Label ID="lblBienvenido" runat="server" Text="¡Bienvenido al Sistema! " Font-Names="Verdana" style="font-size: medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="height: 23px" >
                </td>
            <td style="height: 23px">
                </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" Font-Names="Verdana" style="font-size: small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                <asp:Label ID="lblClave" runat="server" Text="Clave" Font-Names="Verdana" style="font-size: small"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtClave" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td >
                &nbsp;</td>
            <td style="text-align:right">
                <asp:Button ID="btnIngresar" runat="server" onclick="btnIngresar_Click" 
                    Text="Ingresar" style="width: 68px" Font-Names="Verdana" />
            </td>
        </tr>
        </table>
    </div>
    <p>
                <asp:LinkButton ID="lnkRecordarClave" runat="server" 
                    onclick="lnkRecordarClave_Click" Font-Names="Verdana" style="font-size: small">Olvidé mi Clave</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="lblLogin" runat="server" Font-Bold="True" ForeColor="#993333" Font-Names="Verdana" style="font-size: small"></asp:Label>
    </p>
</asp:Content>