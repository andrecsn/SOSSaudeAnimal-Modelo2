<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroFuncionario.aspx.cs" Inherits="ClinicaVeterinaria.cadastroVeterinaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Funcionário"></asp:Label></h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-8">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados básicos de cadastro</b></div>
                    <div class="panel-body">

                        <div class="col-lg-6">
                            <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                            <div class="form-group">
                                <label>Name:</label>
                                <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Endereço:</label>
                                <asp:TextBox ID="txtEndereco" runat="server" class="form-control" placeholder="Endereço completos" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>CEP:</label>
                                <asp:TextBox ID="txtCEP" runat="server" class="form-control cep" placeholder="00000-000" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Telefone:</label>
                                <asp:TextBox ID="txtTelefone" runat="server" class="form-control telefone" placeholder="(xx) xxxx-xxxx" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Cidade:</label>
                                <asp:TextBox ID="txtCidade" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                        </div>


                        <div class="col-lg-6">
                            <div class="form-group">
                                <label>CPF:</label>
                                <asp:TextBox ID="txtCPF" runat="server" class="form-control cpf" placeholder="000.000.000-00" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Bairro:</label>
                                <asp:TextBox ID="txtBairro" runat="server" class="form-control" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="nome@seuemail.com" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Celular:</label>
                                <asp:TextBox ID="txtCelular" runat="server" class="form-control telefone" placeholder="(xx) xxxxx-xxxx" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Estado:</label>
                                <asp:DropDownList ID="cboEstado" runat="server" class="form-control">
                                    <asp:ListItem Value="RJ">Rio de janeiro</asp:ListItem>
                                    <asp:ListItem Value="SP">São paulo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>




                        <div class="col-lg-12">
                            <div class="panel panel-default">
                                <div class="panel-heading">Dados de acesso ao sistema</div>
                                <div class="panel-body">
                                    <div class="row">

                                        <div class="col-xs-4">
                                            <label>Login:</label>
                                            <asp:TextBox ID="txtLogin" runat="server" class="form-control" required></asp:TextBox>
                                        </div>

                                        <div class="col-xs-4">
                                            <label>Senha:</label>
                                            <asp:TextBox ID="txtSenha" runat="server" class="form-control" required TextMode="Password"></asp:TextBox>
                                        </div>

                                        <div class="col-xs-4">
                                            <label>Tipo:</label>
                                            <asp:DropDownList ID="cboTipo" runat="server" class="form-control" required>
                                                <asp:ListItem><-- Selecionar --></asp:ListItem>
                                                <asp:ListItem Value="Atendente">Atendente</asp:ListItem>
                                                <asp:ListItem Value="Veterinária">Veterinária</asp:ListItem>
                                                <asp:ListItem Value="Administrador">Administrador</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="form-group">
                    </br></br></br>
                <img src="../App_Themes/Bootstrap/images/funcionarios.png" class="img-responsive" />
                </div>
            </div>

        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="well well-sm">

                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-success" OnClick="btnCadastrar_Click" />
                    <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-primary" OnClick="btnAlterar_Click" Visible="False" />
                    <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

                </div>
            </div>
        </div>

    </form>

</asp:Content>

