<%@ Page Theme="Theme8" Title="" Language="C#" MasterPageFile="~/MisSalasU.Master" AutoEventWireup="true" CodeBehind="MisSalasU.aspx.cs" Inherits="Club_de_Lectura.MisSalasU1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    &nbsp;<asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    &nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContT" runat="server">
    <p style="margin-left: 40px">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Filtrar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button11" runat="server" Text="Volver a inicio" OnClick="Button11_Click" />
        <asp:GridView ID="GridView1" runat="server" BorderStyle="Dashed" CellSpacing="1" HorizontalAlign="Center" BackColor="White" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
        </asp:GridView>
        <asp:Label ID="Label7" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button10" runat="server" Text="Confirmar seleccion" OnClick="Button10_Click" />
    </p>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContC" runat="server">
    <p style="margin-left: 40px">
        &nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="Button4" runat="server" Text="Eliminar Sala" OnClick="Button4_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button5" runat="server" Text="Agregar Reunion" OnClick="Button5_Click" />
        <br />
        &nbsp;&nbsp;
    <br />
        <asp:Label ID="Label2" runat="server" Text="Nombre sala:"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Libro:"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList2" runat="server">
    </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Tema:"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList3" runat="server">
    </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Cupo:"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="¿Renovar?"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="DropDownList4" runat="server">
    </asp:DropDownList>
    </p>
    <p style="margin-left: 40px">
        <asp:Label ID="Label8" runat="server"></asp:Label>
        <br />
        <asp:Button ID="Button6" runat="server" Text="Guardar Cambios" OnClick="Button6_Click" />
        &nbsp;
    </p>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContU" runat="server">
    <p style="margin-left: 40px">
        <asp:Button ID="Button7" runat="server" Text="Salir de la Sala" OnClick="Button7_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        Reunion seleccionada:
        <asp:Label ID="Label9" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="GridView2" runat="server" BorderStyle="Dashed" CellSpacing="1" HorizontalAlign="Center" BackColor="White" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
        </asp:GridView>
    </p>
    <p style="margin-left: 40px">
        <asp:Button ID="Button9" runat="server" Text="Detalles" OnClick="Button9_Click" />
    </p>
</asp:Content>

