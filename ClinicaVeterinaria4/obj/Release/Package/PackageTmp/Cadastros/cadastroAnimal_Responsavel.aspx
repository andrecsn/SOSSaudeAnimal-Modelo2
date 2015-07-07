<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroAnimal_Responsavel.aspx.cs" Inherits="ClinicaVeterinaria.cadastroAnimal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Animal e Responsável"></asp:Label></h1>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados básicos de cadastro de Animal</b></div>
                    <div class="panel-body">
                        <div class="col-lg-8">

                            <div class="row">
                                <div class="col-lg-6">

                                    <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                                    <div class="form-group">
                                        <label>Nome:</label>
                                        <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <label>Especie:</label>
                                        <asp:DropDownList ID="cboEspecie" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-lg-7">

                                        <div class="row">
                                            <label>Sexo:</label>
                                            <asp:DropDownList ID="cboSexo" runat="server" class="form-control">
                                                <asp:ListItem Value="Macho">Macho</asp:ListItem>
                                                <asp:ListItem Value="Fêmea">Fêmea</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>

                                    <div class="col-lg-5">
                                        <label>Peso:</label>
                                        <asp:TextBox ID="txtPeso" runat="server" class="form-control" placeholder="Ex.: 10gr" required></asp:TextBox>
                                    </div>

                                </div>

                                <div class="col-lg-6">

                                    <div class="form-group">
                                        <label>Pelagem:</label>
                                        <asp:TextBox ID="txtCor" runat="server" class="form-control" required></asp:TextBox>
                                    </div>

                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Data de Nascimento: </label>
                                            <div class='input-group date'>
                                                <asp:TextBox ID="txtNascimento" runat="server" class="form-control data" placeholder="00/00/0000" required></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="form-group">
                                        <label>Raça:</label>
                                        <asp:DropDownList ID="cboRaca" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>

                                </div>

                            </div>

                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="form-group">
                                        <label>Informações:</label>
                                        <asp:TextBox ID="txtInformacoes" runat="server" Rows="4" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                        </div>

                        <div class="col-lg-4 text-center img-responsive">

                            <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Bootstrap/images/sem-foto.jpg" Height="300" Width="300" CssClass="img-circle" />

                            <div class="form-group">
                                <asp:FileUpload ID="arqFoto" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados básicos de cadastro do Responsável</b></div>
                    <div class="panel-body">

                        <div class="col-lg-4">

                            <asp:Label ID="Label2" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                            <div class="form-group">
                                <label>Name:</label>
                                <asp:TextBox ID="txtNomeResp" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>CPF:</label>
                                <asp:TextBox ID="txtCPFResp" runat="server" class="form-control cpf" placeholder="000.000.000-00"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Telefone:</label>
                                <asp:TextBox ID="txtTelefoneResp" runat="server" class="form-control telefone" placeholder="(xx) xxxx-xxxx"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label>Celular:</label>
                                <asp:TextBox ID="txtCelularResp" runat="server" class="form-control telefone" placeholder="(xx) xxxxx-xxxx"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Email:</label>
                                <asp:TextBox ID="txtEmailResp" runat="server" class="form-control" placeholder="nome@seuemail.com"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Endereço:</label>
                                <asp:TextBox ID="txtEnderecoResp" runat="server" class="form-control" placeholder="Endereço completos"></asp:TextBox>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label>Bairro:</label>
                                <asp:TextBox ID="txtBairroResp" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Cidade:</label>
                                <asp:TextBox ID="txtCidadeResp" runat="server" class="form-control"></asp:TextBox>
                            </div>

                            <div class="form-group">
                                <label>Estado:</label>
                                <asp:DropDownList ID="cboEstadoResp" runat="server" class="form-control">
                                    <asp:ListItem Value="RJ">Rio de janeiro</asp:ListItem>
                                    <asp:ListItem Value="SP">São paulo</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="well well-sm">

                    <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-success" OnClick="btnCadastrar_Click" />
                    <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

                </div>
            </div>
        </div>



    </form>
</asp:Content>

