<%@ Page Theme="GenericoAdmin" Title="" Language="C#" MasterPageFile="~/CRUDUsuariosAdmin.Master" AutoEventWireup="true" CodeBehind="CRUDUsuariosAdmin.aspx.cs" Inherits="Club_de_Lectura.CRUDUsuariosAdmin1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    &nbsp;<asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cont" runat="server">
    <p style="margin-left: 40px">
        <asp:GridView ID="GridView1" runat="server" BackColor="White" HorizontalAlign="Center" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <br />
        Clave Usuario:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Buscar" OnClick="Button2_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Text="Confirmar Seleccion" OnClick="Button3_Click" />

        <br />
        <asp:Button ID="Button7" runat="server" Text="Nuevo Usuario" OnClick="Button7_Click" />
        <br />
        <br />
        Nombre:
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        Correo:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        <br />
        Contraseña:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        <br />
        Telefono:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <br />
        Direccion:<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="Actualizar" OnClick="Button4_Click" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button5" runat="server" Text="Eliminar" OnClick="Button5_Click" />
        &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button6" runat="server" Text="Registrar" OnClick="Button6_Click1" />
    &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button8" runat="server" OnClick="Button8_Click" Text="Recargar formulario" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button9" runat="server" OnClick="Button9_Click" Text="Volver" />
    </p>
</asp:Content>
