<%@ Page Theme="Theme4" Language="C#" MasterPageFile="~/PerfilU.Master" AutoEventWireup="true" CodeBehind="PerfilU.aspx.cs" Inherits="Club_de_Lectura.PerfilU1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />&nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cont" runat="server">
            Correo:<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="LC" runat="server"></asp:Label>
    <br />
    <br />Nueva contraseña:<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />Confirmar contraseña:<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
    <br />
    <br />Nombre:<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
    <br />
    <br />
    Telefono:<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
    <br />
    <br />
    Direccion:<br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
    <br />
    <br />
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Guardar Cambios" />
    <br />
    <asp:Label ID="Label2" runat="server"></asp:Label>
    <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Regresar" />
</asp:Content>
