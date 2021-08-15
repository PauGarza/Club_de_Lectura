<%@ Page Theme="Theme3" Title="" Language="C#" MasterPageFile="~/InicioUsuario.Master" AutoEventWireup="true" CodeBehind="InicioUsuario.aspx.cs" Inherits="Club_de_Lectura.InicioUsuario1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    &nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Bt1" runat="server">
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Unirse a una sala" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Bt2" runat="server">
    <asp:Button ID="Button4" runat="server" Text="Crear Sala" OnClick="Button4_Click" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="Bt3" runat="server">
    <asp:Button ID="Button5" runat="server" Text="Mis Salas" OnClick="Button5_Click" />
</asp:Content>
