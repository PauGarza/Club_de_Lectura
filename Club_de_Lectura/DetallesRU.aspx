<%@ Page Theme="Theme4" Title="" Language="C#" MasterPageFile="~/DetallesRU.Master" AutoEventWireup="true" CodeBehind="DetallesRU.aspx.cs" Inherits="Club_de_Lectura.DetallesRU1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Cab" runat="server">
    <asp:Label ID="Label1" runat="server"></asp:Label>
    <br />
    &nbsp;<asp:Button ID="Button2" runat="server" Text="Administrar" OnClick="Button2_Click" />
    <asp:Button ID="Button1" runat="server" BorderStyle="Ridge" OnClick="Button1_Click" Text="Cerrar Sesion" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Cont" runat="server">
    <p style="margin-left: 40px">
        <asp:Button ID="Button7" runat="server" Text="Eliminar" Width="88px" OnClick="Button7_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <p>
        Id Reunion:
        </p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            IdSala:
        </p>
        <p style="margin-left: 40px">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </p>
        <p>
            Fecha:
        </p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;[AAAA-MM-DD]
        </p>
        <p>
            Hora:
        </p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            &nbsp;[HH:MM] (24 hrs)
        </p>
        <p>
            Duracion:
        </p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBox1" runat="server" Height="20px" Width="172px"></asp:TextBox>
            (minutos)
        </p>
        <p>
            Link:
        </p>
        <p style="margin-left: 40px">
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Ir a meet" />
        </p>
        <p style="margin-left: 40px">
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </p>
        <p>
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Guardar" />
            &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Regresar" />
        </p>
    </p>
</asp:Content>
