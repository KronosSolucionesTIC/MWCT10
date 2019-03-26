<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="rango" runat="server" Text="Rango"></asp:Label>

               <asp:Calendar ID="txtFecha" runat="server"></asp:Calendar>

    <br />

               <asp:Label ID="Label1" runat="server" Text="Cliente"></asp:Label>

           <asp:DropDownList ID="cliente" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
          </asp:DropDownList>

    <br />
               <asp:Label ID="Label2" runat="server" Text="Estado"></asp:Label>

                   <asp:DropDownList ID="estado" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
                       <asp:ListItem Value="1">Pendiente</asp:ListItem>
          </asp:DropDownList>
    <br />
    <br />

    <div class="align-items-md-center">
        <asp:Button ID="actualizar" runat="server" Text="Actualizar" class="btn btn-success" Width="150px" OnClick="actualizar_Click"/>
        <br />
        <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" Width="150px" />
    </div>


                   </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
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
