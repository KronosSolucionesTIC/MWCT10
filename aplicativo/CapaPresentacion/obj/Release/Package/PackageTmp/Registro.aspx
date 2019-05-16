﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="CapaPresentacion.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" Width="150px" OnClick="cerrar_Click" />
    <asp:Label ID="cliente" class="cliente" runat="server"></asp:Label>
    <asp:Label class="cliente" runat="server">/</asp:Label>
    <asp:Label ID="usuario" class="cliente" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
<!-- Modal -->
<div class="modal fade" id="registroModal" tabindex="-1" role="dialog" aria-labelledby="registroModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="registroModalLabel">Registro correcto</h5>
      </div>
      <div class="modal-body">
        Se ha finalizado de forma correcta el ingreso de los medidores.<br />
        El Acta de Entrada con el que fue registrado el proceso es: <input runat="server" type="text" id="documento" />
      </div>
      <div class="modal-footer">
        <asp:button text="Continuar" class="btn btn-success" runat="server" OnClick="redireccionar"></asp:button>
      </div>
    </div>
  </div>
</div>
</asp:Content>
