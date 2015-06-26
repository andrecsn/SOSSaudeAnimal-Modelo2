<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.login" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>Clinica Veterinária</title>

    <style>
        .rodape {
            position: absolute;
            bottom: 0;
            width: 100%;
        }

        .panel-default {
            opacity: 0.9;
            margin-top: 70px;
        }
        .container
        {
            position: relative;
            z-index: 9999;
        }
    </style>

</head>

<body>
    <form id="form1" runat="server" class="form-horizontal">


         <!-- Static navbar -->
        <nav class="navbar navbar-default navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <a class="navbar-brand" href="#">SOS Saúde Animal</a>
                </div>
                <!--/.nav-collapse -->
            </div>
            <!--/.container-fluid -->
        </nav>


        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <strong class="">Login</strong>

                        </div>
                        <div class="panel-body">
                            <div class="form-group">
                                <label for="inputEmail3" class="col-sm-3 control-label">Login</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtUsuario" class="form-control" runat="server" placeholder="Login" required="" autofocus></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="inputPassword3" class="col-sm-3 control-label">Senha</label>
                                <div class="col-sm-9">
                                    <asp:TextBox ID="txtSenha" class="form-control" runat="server" placeholder="Senha" required="" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-offset-3 col-sm-9">
                                    <div class="checkbox">
                                        <label class="">
                                            <input type="checkbox" class="">Lembrar-me</label>
                                    </div>
                                </div>
                            </div>
                            <div class="form-group last">
                                <div class="col-sm-offset-3 col-sm-9">
                                    <asp:Button ID="btnEntrar" class="btn btn-success btn-sm" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                                    <button type="reset" class="btn btn-default btn-sm">Limpar</button>
                                </div>
                            </div>
                        </div>
                        <div class="panel-footer">
                            Clínica Veterinária - SOS Saúde Animal
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="rodape"><img src="../App_Themes/Bootstrap/images/cachorro-e-veterinário.jpg" class="img-responsive" /></div>
    </form>
</body>
</html>
