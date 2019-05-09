<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Estilo/images/con_tarea.png" OnClick="ImageButton1_Click" />
            <br />
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Estilo/images/con_doc.png" />
            <br /> 
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Estilo/images/carga_archi.png" OnClick="ImageButton3_Click" />
            <br /> 
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Estilo/images/crea_tarea.png" OnClick="ImageButton4_Click"  />
            <br />
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <Label ID="Label" runat="server" Class="etiquetas text-center">Tipo de grupo</Label>
            <br />
            <input id="Individual" type="checkbox" checked runat="server"/>Individual
            <input id="Unico" type="checkbox" runat="server"/>Unico
            <br />
            <Label ID="medidores" runat="server" Class="etiquetas text-center">Cantidad medidores</Label>
            <input type="text" id="cant_medidores" runat="server" Class="cajas" value="0" />
            <br />
            <br />
            <Label ID="doc" runat="server" Class="etiquetas text-center">Documento entrada</Label>
            <input type="text" ID="doc_entrada" runat="server" Class="cajas" disabled/>
            <br />
            <br />
            <asp:Button enabled="false" ID="act_cantidad" runat="server" Text="Agregar" width="100%" Class="btn btn-success" OnClick="actualizar_Click" />
            <asp:Button enabled="false" ID="eliminar" runat="server" Text="Eliminar" width="100%" Class="btn btn-danger" />
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
    <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_Selected" AutoPostBack="true">
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
    <asp:TextBox runat="server" ID="nombreGrupo" ReadOnly/>
    <br />
        </div>
    </div>
      </div>
      <div class="modal-footer">
        <asp:Button runat="server" Text="Cancelar" id="cancelar" class="btn btn-danger" Width="150px" data-dismiss="modal"></asp:Button>
        <asp:Button runat="server" Text="Continuar" id="grupo_ok" class="btn btn-success" Width="150px" onClick="continuar_Click"/></asp:Button>
      </div>
    </div>
  </div>
</div>
<div class="modal fade" id="modalSerial" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="modalSerialLabel">Definir Serial</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
 <div class="row">
        <div class="col-12">
    <div class="row">
        <div class="col-12">
            <asp:Label runat="server">Serial</asp:Label>
            <input type="text" ID="serial" runat="server" value="Serial" required></input>
            <asp:Label class="etiquetas" runat="server" Text="Zona"></asp:Label>
            <asp:DropDownList ID="zona" class="cajas" runat="server" >
            </asp:DropDownList>
            <asp:Label class="etiquetas" runat="server" Text="Codigos de error"></asp:Label>
            <asp:DropDownList ID="codigos" class="cajas" runat="server" >
            </asp:DropDownList>
            <br />
            <asp:Button ID="ayuda" runat="server" Text="Ayuda" class="btn btn-warning" Width="150px" OnClick="ayuda_Click"/>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="6" Visible="False" >
           
        <Columns>
            <asp:BoundField DataField="CODE" HeaderText="Codigo" />
            <asp:BoundField DataField="DESCRIPTION" HeaderText="Descripcion" />
        </Columns>

            </asp:GridView>
             <asp:TextBox runat="server" id="TxtError"></asp:TextBox>
            <asp:HiddenField ID="ok" runat="server" value="0"/>
        </div>
    </div>
        </div>
    </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
        <asp:Button runat="server" Text="Continuar" id="Button1" class="btn btn-success" Width="150px" onClick="asignaSerial"/></asp:Button>
      </div>
    </div>
  </div>
</div>
    <div class="row">
        <div class="col-6 text-center">
            <button runat="server" id="habilitar_grupo" type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModalLive" disabled>Habilitar grupo</button>   
        </div>
        <div class="col-6 text-center">
            <button runat="server" id="habilitar_serial" type="button" class="btn btn-primary" data-toggle="modal" data-target="#modalSerial" disabled>Habilitar serial</button>
        </div>
    <div>
    <div class="row">
        <div class="col-12">
            <asp:HiddenField ID="Item_actual" runat="server" value="0"/>
            <asp:HiddenField ID="Saldo" runat="server"/>
            <asp:Table id="Table1" runat="server" CssClass="tabla2">
                <asp:TableRow>
                    <asp:TableCell>
                        Serial
                    </asp:TableCell>
                    <asp:TableCell>
                        Grupo
                    </asp:TableCell>
                    <asp:TableCell>
                        Zona
                    </asp:TableCell>
                    <asp:TableCell>
                        Codigo de ingreso
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
    </div>
    </div>
        </div>
</asp:Content>