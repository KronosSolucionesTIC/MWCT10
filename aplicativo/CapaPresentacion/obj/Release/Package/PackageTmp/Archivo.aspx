<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Archivo.aspx.cs" Inherits="CapaPresentacion.Archivo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    <form id="form1">
    <div>
    
        <asp:FileUpload ID="fuPrueba" Class="btn btn-info" runat="server" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnProcesar" Class="btn btn-success" runat="server" OnClick="btnProcesar_Click" Text="Procesar" />
&nbsp;&nbsp;
        <asp:Label ID="lblMensaje" runat="server" Text="esto es un caso de prueba :)" Font-Size="X-Large"></asp:Label>
        <br />
        <asp:GridView ID="gv" runat="server" CssClass="tabla">
        </asp:GridView>
        <asp:GridView ID="gv3" runat="server">
        </asp:GridView>
        <asp:Button ID="btn_guardar" Class="btn btn-success" runat="server" OnClick="salvar_Click" Text="Salvar" />

        <br />
    </div>
    </form>
</asp:Content>