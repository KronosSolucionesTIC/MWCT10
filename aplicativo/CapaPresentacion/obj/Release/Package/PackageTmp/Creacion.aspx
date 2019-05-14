<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12 text-center">
            <h3>Creacion de tareas</h3>
        </div>
    </div>
     <div class="row">
        <div class="col-lg-12">
            <Label ID="medidores" runat="server" Class="etiquetas text-center">Cantidad medidores</Label>
        </div>
     </div>
     <div class="row">
        <div class="col-lg-12 text-center">
            <input type="text" id="cant_medidores" runat="server" Class="cajas" value="0" />
        </div>
     </div>
     <div class="row">
         <div class="col-lg-6 text-center">
            <button disabled type="button" ID="agregar_dispositivo" runat="server" class="btn btn-success" data-toggle="modal" data-target="#exampleModalLive">
                Agregar dispositivo
            </button>
         </div>
         <div class="col-lg-6 text-center">
            <input disabled type="button" ID="eliminar_dispositivo" runat="server" Value="Eliminar Dispositivo" Class="btn btn-danger" />
         </div>
     </div>
<div class="modal fade" id="exampleModalLive" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Informacion adicional</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body">
 <div class="row">
        <div class="col-12">
                <asp:Label runat="server">Informacion adicional</asp:Label>
    <br />
    <br />
    <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Marca medidor"></asp:Label>
    <asp:DropDownList ID="marca" class="cajas" runat="server" OnSelectedIndexChanged="marca_Selected" AutoPostBack="true">
    </asp:DropDownList>
        <asp:Label ID="Label4" class="etiquetas" runat="server" Text="Modelo medidor"></asp:Label>
    <asp:DropDownList ID="modelo" class="cajas" runat="server" >
    </asp:DropDownList>
        <asp:Label class="etiquetas" runat="server" Text="Zona"></asp:Label>
        <asp:DropDownList ID="zona" class="cajas" runat="server" >
        </asp:DropDownList>
        <asp:Label class="etiquetas" runat="server" Text="Codigos de error"></asp:Label>
        <asp:DropDownList ID="codigos" class="cajas" runat="server" >
        </asp:DropDownList>       
        <asp:Label runat="server">Serial</asp:Label>
        <input type="text" ID="serial" runat="server" placeholder="Serial Medidor" required />
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
    <asp:TextBox runat="server" ID="nombreGrupo" ReadOnly/>
    <br />
        </div>
    </div>
      </div>
      <div class="modal-footer">
        <asp:Button runat="server" Text="Cancelar" id="cancelar" class="btn btn-danger" Width="150px" data-dismiss="modal"></asp:Button>
        <asp:Button runat="server" Text="Aceptar" id="grupo_ok" class="btn btn-success" Width="150px" onClick="continuar_Click"/></asp:Button>
      </div>
    </div>
  </div>
</div>
    <div class="row">
        <div class="col-6 text-center">
        </div>
        <div class="col-6 text-center">
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <asp:HiddenField ID="Item_actual" runat="server" value="0"/>
            <asp:HiddenField ID="Saldo" runat="server"/>
        </div>
    </div>
    <div class="row">
        <div class="col-12">
            <div style="overflow:scroll;width:100%;height:300px;">        
                <asp:GridView ID="gv2" CssClass="tabla" runat="server" Height="300px">
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Total medidores <asp:Label id="total_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="total" value="0" runat="server" />
            </div>
        </div>
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Listados <asp:Label id="listados_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="listados" value="0" runat="server" />
            </div>
        </div>
        <div class="col-lg-4 text-center">
            <div class="alert alert-warning" role="alert">
                Faltantes <asp:Label id="faltantes_mask" class="contadores" runat="server" Text="0"></asp:Label>
                <input type="hidden" id="faltantes" value="0" runat="server" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12 text-center">
            <input type="hidden" id="confirmado" value="0" runat="server" />
            <input type="button" disabled ID="guardar" runat="server" Value="Guardar" Class="btn btn-success" OnClick="actualizar_Click" />
        </div>
    </div>
</asp:Content>