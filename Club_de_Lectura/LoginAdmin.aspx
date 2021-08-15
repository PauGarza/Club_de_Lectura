<%@ Page Theme="Theme5" Title="" Language="C#" MasterPageFile="~/LoginAdmin.Master" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="Club_de_Lectura.LoginAdmin1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="PLogin">
        <p style="margin-left: 10px">&nbsp;</p>
        <p style="margin-left: 50px">Club de Lectura [Admin]<br />
            <br />
            Ingresa tu clave:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            Ingresa tu contraseña:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" Style="height: 29px" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Ingresar como Usuario" />
        </p>

    </div>
    </p>
</asp:Content>
