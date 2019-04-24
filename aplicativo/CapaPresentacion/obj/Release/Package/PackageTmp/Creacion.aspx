<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Creacion.aspx.cs" Inherits="CapaPresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
        <div class="col-12 text-center">
            <h3>Creacion de tareas</h3>
        </div>
    </div>
    <div class="row">
        <div class="col-4">
            <asp:Label ID="Label7" runat="server" Text="Cantidad/Documento"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Class="etiquetas" Text="Cantidad de medidores"></asp:Label>
            <input type="text" id="cant_medidores" runat="server" Class="cajas" value="0" />
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Class="etiquetas" Text="Documentos de entrada"></asp:Label>
            <asp:TextBox ID="doc_entrada" runat="server" Class="cajas"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="act_cantidad" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" OnClick="actualizar_Click" />
            <br />
        </div>
        <div class="col-4">
            <asp:Label ID="Label8" runat="server" Text="Grupo"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Class="etiquetas" Text="Tipo de grupo"></asp:Label>
            <asp:DropDownList ID="tipoGrupo" runat="server" Enabled="False">
                <asp:ListItem Value="0">Seleccione...</asp:ListItem>
                <asp:ListItem>Unico</asp:ListItem>
                <asp:ListItem>Individual</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <br />
            <br />
            <asp:Button ID="act_grupo" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" Enabled="False" OnClick="act_grupo_Click" />
            <br />
        </div>
        <div class="col-4">
            <asp:Label ID="Label9" runat="server" Text="Serial"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label5" runat="server" Class="etiquetas" Text="Cantidad de medidores"></asp:Label>
            <asp:TextBox ID="TextBox3" runat="server" Class="cajas" TextMode="Number">0</asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label6" runat="server" Class="etiquetas" Text="Documentos de entrada"></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" Class="cajas"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="act_serial" runat="server" Text="Actualizar" width="100%" Class="btn btn-success" Enabled="False" />
            <br />
        </div>
    <div>
    <div class="row">
        <div class="col-12">
            <h3>Creacion de tareas</h3>
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