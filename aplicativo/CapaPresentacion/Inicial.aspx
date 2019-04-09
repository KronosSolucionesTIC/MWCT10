<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label Text="Session['Login']" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
    <div class="col-1">
        <asp:Label ID="Fec_ini" runat="server" Text="Fecha Inicial"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Estilo/images/calendario.png" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    </div>
    
    <div class="col-1">
        <asp:Label ID="Fec_fin" runat="server" Text="Fecha Final"></asp:Label>

    
    <asp:DropDownList ID="fechaFinal" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-2">
        <asp:Label ID="Doc_Ent" runat="server" Text="Documento de entrada"></asp:Label>

    
    <asp:DropDownList ID="docEntrada" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-2">
        <asp:Label ID="Num_Ser" runat="server" Text="Numero de serial"></asp:Label>

    
    <asp:DropDownList ID="numeroSerial" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    
    </div>

    <div class="col-2">
        <asp:Label ID="Nom_Gru" runat="server" Text="Nombre de grupo"></asp:Label>

    
    <asp:DropDownList ID="nombreGrupo" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

    </div>

    <div class="col-2">
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
        <asp:Button ID="actualizar" runat="server" Text="Buscar" class="btn btn-success" Width="150px" OnClick="actualizar_Click"/>
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
