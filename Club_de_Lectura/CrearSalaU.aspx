<%@ Page Theme="Theme4" Language="C#" MasterPageFile="~/CrearSalaU.Master" AutoEventWireup="true" CodeBehind="CrearSalaU.aspx.cs" Inherits="Club_de_Lectura.CrearSalaU1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />&nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cont" runat="server">
    <p>
        Nueva Sala</p>
    <p>
        Nombre de Sala:
    </p>
    <p style="margin-left: 40px">
        <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="172px"></asp:TextBox>
    </p>
    <p>
        Tema:
    </p>
    <p style="margin-left: 40px">
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Libro:</p>
    <p style="margin-left: 40px">
        <asp:DropDownList ID="DropDownList2" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Cupo:</p>
    <p style="margin-left: 40px">
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
    </p>
    <p style="margin-left: 40px">
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </p>
    <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Crear Sala" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Regresar" />
    </p>
</asp:Content>