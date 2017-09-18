<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reporte.aspx.cs" Inherits="UI.Web.Reporte" %>
<%@ Register assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="bodyContentPlaceHolder" runat="server">

    <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" 
        AutoDataBind="True" Height="1123px" ReportSourceID="CursosODBC" Width="890px" />
    <CR:CrystalReportSource ID="CursosODBC" runat="server">
        <Report FileName="C:\Users\MaximilianoDaniel\Desktop\TP2\UI.Desktop\CursosODBC.rpt">
        </Report>
    </CR:CrystalReportSource>

</asp:Content>
