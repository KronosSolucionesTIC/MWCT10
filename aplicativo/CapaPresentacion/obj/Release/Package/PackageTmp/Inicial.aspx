<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
    <div class="col-1">
        <asp:Label ID="Fec_ini" runat="server" Text="Fecha Inicial"></asp:Label>
        <asp:DropDownList ID="fechaInicial" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
        </asp:DropDownList>
    </div>
    
    <div class="col-1">
        <asp:Label ID="Fec_fin" runat="server" Text="Fecha Final"></asp:Label>

    
    <asp:DropDownList ID="fechaFinal" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-1">
        <asp:Label ID="Label3" runat="server" Text="Cliente"></asp:Label>

    
    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-1">
        <asp:Label ID="Doc_Ent" runat="server" Text="Documento de entrada"></asp:Label>

    
    <asp:DropDownList ID="docEntrada" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-1">
        <asp:Label ID="Num_Ser" runat="server" Text="Numero serial"></asp:Label>

    
    <asp:DropDownList ID="numeroSerial" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-1">
        <asp:Label ID="Nom_Gru" runat="server" Text="Nombre de grupo"></asp:Label>

    
    <asp:DropDownList ID="nombreGrupo" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    </div>

    <div class="col-1">
        <asp:Label ID="Esta_Acti" runat="server" Text="Estado actividad"></asp:Label>

    <asp:DropDownList ID="estadoActividad" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
                       <asp:ListItem Value="0">Precarga</asp:ListItem>
                       <asp:ListItem Value="1">Alistamiento inicial</asp:ListItem>
                       <asp:ListItem Value="5">Operacion en mesas</asp:ListItem>
                       <asp:ListItem Value="9">Revision de certificado</asp:ListItem>
                       <asp:ListItem Value="11">Etapa de salida</asp:ListItem>
                       <asp:ListItem Value="12">En tramite</asp:ListItem>
                       <asp:ListItem Value="16">Rechazo de recepcion</asp:ListItem>
                       <asp:ListItem Value="17">No recibido en sitio</asp:ListItem>
          </asp:DropDownList>
    
    </div>
    </div>
    <br />

    
    <br />

    <div class="align-items-md-center">
        <asp:Button ID="actualizar" runat="server" Text="Actualizar" class="btn btn-success" Width="150px" OnClick="actualizar_Click"/>
        <br />        
    </div>

    <asp:SqlDataSource ID="tareas" runat="server">

    </asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" DataKeyNames="ID_TBACTYMTR" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:BoundField DataField="DOC_ENTRY" HeaderText="Documento Entrada" />
            <asp:BoundField DataField="DATE_ENTRY" HeaderText="Fecha Creacion" />
            <asp:BoundField DataField="ID_STATE" HeaderText="Estado" />
        </Columns>

        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />

    </asp:GridView>
</asp:Content>
