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
                   <asp:Button ID="Button1" runat="server" Text="Actualizar" class="btn-success"/>

                   <br />
                    
    <asp:Button ID="cerrar" runat="server" Text="Cerrar Sesion"  class="btn btn-danger" OnClick="cerrar_Click" />

                   </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:SqlDataSource ID="Usuarios" runat="server"
        ConnectionString="Data Source=.;Initial Catalog =PROYECTO; Integrated security=true"
        ProviderName="System.Data.SqlClient"
        SelectCommand="SELECT *
        FROM TB_CLIENT">

    </asp:SqlDataSource>

    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="false" DataKeyNames="ID_TBCLIENT"
        DataSourceID="Usuarios">
        <Columns>
            <asp:BoundField DataField="ID_TBCLIENT" HeaderText="Identificador" />
            <asp:BoundField DataField="NAME_CLIENT" HeaderText="Nombre" />
        </Columns>

    </asp:GridView>
</asp:Content>
