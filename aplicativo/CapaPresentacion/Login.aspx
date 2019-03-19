﻿<%@ Page enableEventValidation="false" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CapaPresentacion.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>                       
<!--===============================================================================================-->	
	<link rel="icon" type="image/png" href="images/icons/favicon.ico"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/bootstrap/css/bootstrap.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/fonts/font-awesome-4.7.0/css/font-awesome.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/fonts/Linearicons-Free-v1.0.0/icon-font.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/animate/animate.css"/>
<!--===============================================================================================-->	
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/css-hamburgers/hamburgers.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/vendor/select2/select2.min.css"/>
<!--===============================================================================================-->
	<link rel="stylesheet" type="text/css" href="Estilo/css/util.css"/>
	<link rel="stylesheet" type="text/css" href="Estilo/css/main.css"/>
<!--===============================================================================================-->
    <title></title>
</head>
<body>
    	<div class="limiter">
		<div class="container-login100" style="background-image: url('images/img-01.jpg');">
			<div class="wrap-login100 p-t-190 p-b-30">

                 <form id="form2" runat="server" class="login100-form validate-form">
			
					<div class="login100-form-avatar">
						<img src="Estilo/images/log.jpg" alt="AVATAR"/>
					</div>

					<span class="login100-form-title p-t-20 p-b-45">
						Iniciar Sesión
					</span>

					<div class="wrap-input100 validate-input m-b-10" data-validate = "Username is required">
                        <asp:TextBox ID="Usuario" runat="server" class="input100" type="text" name="username" placeholder="Usuario"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-user"></i>
						</span>
					</div>

					<div class="wrap-input100 validate-input m-b-10" data-validate = "Password is required">
                        <asp:TextBox ID="Contraseña" runat="server" class="input100" type="password" name="pass" placeholder="Contraseña"></asp:TextBox>
						<span class="focus-input100"></span>
						<span class="symbol-input100">
							<i class="fa fa-lock"></i>
						</span>
					</div>

					<div class="container-login100-form-btn p-t-10">
                            <asp:Button ID="Iniciar" runat="server" class="login100-form-btn" Text="Iniciar " OnClick="Iniciar_Click" />
							
					        <asp:HiddenField ID="TextoContador" runat="server" Value="0" />
							
					</div>

				</form>
			</div>
		</div>
	</div>












</html>
