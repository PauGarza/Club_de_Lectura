<%@ Page Theme="Theme4" Title="" Language="C#" MasterPageFile="~/NuevaReunionU.Master" AutoEventWireup="true" CodeBehind="NuevaReunionU.aspx.cs" Inherits="Club_de_Lectura.NuevaReunionU1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    <asp:Label ID="Label1" runat="server"></asp:Label>
<br />&nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
<asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cont" runat="server">
    <p>
    Nueva Reunion</p>
<p>
    Fecha:
</p>
<p style="margin-left: 40px">
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
&nbsp;[AAAA-MM-DD]</p>
<p>
    Hora:</p>
<p style="margin-left: 40px">
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
&nbsp;[HH:MM] (24 hrs)</p>
<p>
    Duracion:</p>
<p style="margin-left: 40px">
    <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="172px"></asp:TextBox>
    (minutos)</p>
<p>
    Link:</p>
<p style="margin-left: 40px">
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Ir a meet" />
</p>
<p style="margin-left: 40px">
    <asp:Label ID="Label2" runat="server"></asp:Label>
</p>
<p>
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Crear Reunion" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Regresar" />
</p>
</asp:Content>
