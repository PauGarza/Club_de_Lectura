<%@ Page Theme="InicioA" Title="" Language="C#" MasterPageFile="~/InicioAdmin.Master" AutoEventWireup="true" CodeBehind="InicioAdmin.aspx.cs" Inherits="Club_de_Lectura.InicioAdmin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
<br />&nbsp;<asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="bt1" runat="server">
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Usuarios" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="bt2" runat="server">
    <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Salas" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="bt3" runat="server">
    <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Libros" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="bt5" runat="server">
    <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="Temas" />
</asp:Content>
