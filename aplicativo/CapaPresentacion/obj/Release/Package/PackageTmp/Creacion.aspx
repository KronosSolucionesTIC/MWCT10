<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Estilo/images/con_tarea.png" OnClick="ImageButton1_Click" />
            <br />
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Estilo/images/con_doc.png" />
            <br /> 
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Estilo/images/carga_archi.png" />
            <br /> 
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Estilo/images/crea_tarea.png" OnClick="ImageButton4_Click"  />
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <Label ID="Label" runat="server" Class="etiquetas text-center">Tipo de grupo</Label>
            <br />
            <input id="Individual" type="checkbox" />Individual
            <input id="Unico" type="checkbox" />Unico
            <br />
            <Label ID="medidores" runat="server" Class="etiquetas text-center">Cantidad medidores</Label>
            <input type="text" id="cant_medidores" runat="server" Class="cajas" value="0" />
            <br />
            <br />
            <Label ID="doc" runat="server" Class="etiquetas text-center">Documento entrada</Label>
            <asp:TextBox ID="doc_entrada" runat="server" Class="cajas"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="act_cantidad" runat="server" Text="Agregar" width="100%" Class="btn btn-success" OnClick="actualizar_Click" />
            <asp:Button ID="eliminar" runat="server" Text="Eliminar" width="100%" Class="btn btn-danger" />
            <br />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12 text-center">
            <h3>Creacion de tareas</h3>
        </div>
    </div>
<div class="modal fade" id="exampleModalLive" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Definir grupo</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
 <div class="row">
        <div class="col-12">
                <asp:Label runat="server">Definicion grupo</asp:Label>
    <br />
    <br />
    <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Marca"></asp:Label>
    <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_SelectedIndexChanged" AutoPostBack="True" >
    </asp:DropDownList>
        <asp:Label ID="Label4" class="etiquetas" runat="server" Text="Modelo"></asp:Label>
    <asp:DropDownList ID="modelo" class="cajas" runat="server" >
    </asp:DropDownList>
        <asp:Label ID="Label10" class="etiquetas" runat="server" Text="Tipo de energia"></asp:Label>
    <asp:DropDownList ID="energia" class="cajas" runat="server" >
        <asp:ListItem Value="0">Seleccione...</asp:ListItem>
        <asp:ListItem Value="1">Activa</asp:ListItem>
        <asp:ListItem Value="2">Reactiva</asp:ListItem>
    </asp:DropDownList>
        <asp:Label ID="Label11" class="etiquetas" runat="server" Text="Fases/Hilos"></asp:Label>
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

        </div>
    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
        <asp:Button runat="server" Text="Continuar"  class="btn btn-success" Width="150px" />
      </div>
    </div>
  </div>
</div>
    <div class="row">
        <div class="col-6 text-center">
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLive" disabled>Habilitar grupo</button>   
        </div>
        <div class="col-6 text-center">
            <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLive" disabled>Habilitar serial</button>
        </div>
    <div>
    <div class="row">
        <div class="col-12">
            <asp:Table id="Table1" runat="server" CellPadding="10" 
                GridLines="Both"
                HorizontalAlign="Center" CssClass="mGRID">
                <asp:TableRow>
                    <asp:TableCell>
                        Documento de entrada
                    </asp:TableCell>
                    <asp:TableCell>
                        Grupo
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    </div>
        </div>
</asp:Content>