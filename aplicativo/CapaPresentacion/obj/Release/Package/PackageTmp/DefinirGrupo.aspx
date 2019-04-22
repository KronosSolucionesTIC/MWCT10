<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DefinirGrupo.aspx.cs" Inherits="CapaPresentacion.DefinirGrupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    <asp:Label runat="server">Definicion grupo</asp:Label>
    <br />
    <br />
    <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_SelectedIndexChanged" >
    </asp:DropDownList>
        <asp:Label ID="Label1" class="etiquetas" runat="server" Text="Modelo"></asp:Label>
    <asp:DropDownList ID="modelo" class="cajas" runat="server" OnSelectedIndexChanged="modelo_SelectedIndexChanged" >
    </asp:DropDownList>
        <asp:Label ID="Label2" class="etiquetas" runat="server" Text="Tipo de energia"></asp:Label>
    <asp:DropDownList ID="energia" class="cajas" runat="server" OnSelectedIndexChanged="energia_SelectedIndexChanged" >
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
        <asp:ListItem Value="1">Activa</asp:ListItem>
        <asp:ListItem Value="2">Reactiva</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label3" class="etiquetas" runat="server" Text="Fases/Hilos"></asp:Label>
    <asp:DropDownList ID="fase" class="cajas" runat="server" >
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
        <asp:ListItem Value="A">Fase 1 / Hilos 2</asp:ListItem>
        <asp:ListItem Value="B">Fase 1 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="C">Fase 2 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="D">Fase 3 / Hilos 3</asp:ListItem>
        <asp:ListItem Value="E">Fase 3 / Hilos 4</asp:ListItem>
    </asp:DropDownList>
    <br />
    <asp:HiddenField runat="server" ID="nombreGrupo" />
    <br />
    <asp:Button ID="continuar" runat="server" Text="Continuar"  class="btn btn-success" Width="150px" OnClick="continuar_Click" />
    <asp:Button ID="cancelar" runat="server" Text="Cancelar"  class="btn btn-danger" Width="150px" OnClick="cancelar_Click" />
</asp:Content>
