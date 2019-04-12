<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    <asp:Label ID="usuario" class="usuario" runat="server"></asp:Label>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Menu" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Contenido" runat="server">
    <div class="row">
    <div class="col-12">
        <asp:Label ID="Fec_ini" class="etiquetas" runat="server" Text="Inicial"></asp:Label>

        <asp:TextBox ID="TextBox1" runat="server" class="cajas"></asp:TextBox>
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Estilo/images/calendario.png" OnClick="ImageButton1_Click" />
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="Calendar1_SelectionChanged">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>
    
        <asp:Label ID="Fec_fin" class="etiquetas" runat="server" Text="Final"></asp:Label>

    
        <asp:TextBox ID="TextBox2" runat="server" class="cajas"></asp:TextBox>
        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="Estilo/images/calendario.png" OnClick="ImageButton2_Click" />
        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" OnSelectionChanged="Calendar2_SelectionChanged" Width="220px">
            <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px" />
            <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF" />
            <OtherMonthDayStyle ForeColor="#999999" />
            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
            <SelectorStyle BackColor="#99CCCC" ForeColor="#336666" />
            <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px" />
            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
            <WeekendDayStyle BackColor="#CCCCFF" />
        </asp:Calendar>

        <asp:Label ID="Doc_Ent" class="etiquetas" runat="server" Text="Doc. Entrada"></asp:Label>

    
    <asp:DropDownList ID="docEntrada" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>
        </div>
        </div>
    <br />
    <div class="row">
        <div class="col-12">
        <asp:Label ID="Num_Ser" class="etiquetas" runat="server" Text="Num serial"></asp:Label>

    
    <asp:DropDownList ID="numeroSerial" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

        <asp:Label ID="Nom_Gru" class="etiquetas" runat="server" Text="Grupo"></asp:Label>

    
    <asp:DropDownList ID="nombreGrupo" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
    </asp:DropDownList>

        <asp:Label ID="Esta_Acti" runat="server" class="etiquetas" Text="Estado"></asp:Label>

    <asp:DropDownList ID="estadoActividad" class="cajas" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
                       <asp:ListItem Value="0">Precarga</asp:ListItem>
                       <asp:ListItem Value="1">Alistamiento inicial</asp:ListItem>
                       <asp:ListItem Value="5">Operacion en mesas</asp:ListItem>
                       <asp:ListItem Value="9">Revision de certificado</asp:ListItem>
                       <asp:ListItem Value="11">Etapa de salida</asp:ListItem>
                       <asp:ListItem Value="12">En tramite</asp:ListItem>
                       <asp:ListItem Value="16">Rechazo de recepcion</asp:ListItem>
                       <asp:ListItem Value="2">No recibido en sitio</asp:ListItem>
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

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None"
                AllowPaging="true" CssClass="mGrid" PagerStyle-CssClass="pgr" AlternatingRowStyle-CssClass="alt"
                PageSize="6" >
        <Columns>
            <asp:BoundField DataField="DOC_ENTRY" HeaderText="Documento Entrada" />
            <asp:BoundField DataField="NUM_SERIAL" HeaderText="Numero de serial" />
            <asp:BoundField DataField="NAME_GROUP" HeaderText="Nombre del grupo" />
            <asp:BoundField DataField="DATE_ENTRY" HeaderText="Fecha de ingreso" />
            <asp:BoundField DataField="DATE_ENTRY" HeaderText="Nombre certificado" />
            <asp:BoundField DataField="ID_STATE" HeaderText="Estado actual" />
        </Columns>

    </asp:GridView>

            <div>
        </div>
</asp:Content>
