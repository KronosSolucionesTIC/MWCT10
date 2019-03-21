<%@ Page  enableEventValidation="false" Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="CapaPresentacion.Inicial" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

           <asp:DropDownList ID="ciudad" runat="server" OnSelectedIndexChanged="ciudad_SelectedIndexChanged">
          </asp:DropDownList>


</asp:Content>
