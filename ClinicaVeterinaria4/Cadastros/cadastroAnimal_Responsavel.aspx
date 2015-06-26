<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroAnimal_Responsavel.aspx.cs" Inherits="ClinicaVeterinaria.cadastroAnimal" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>
            <asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Animal"></asp:Label></h2>
        <h4>Preencha todos os dados de Animal corretamente.</h4>

        </br>


            <div class="row">

                <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                <div class="col-xs-8">
                    <label for="usr">Name:</label>
                    <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Pelagem:</label>
                    <asp:TextBox ID="txtCor" runat="server" class="form-control" required></asp:TextBox>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Peso:</label>
                    <asp:TextBox ID="txtPeso" runat="server" class="form-control" placeholder="Ex.: 10gr" required></asp:TextBox>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Sexo:</label>
                    <asp:DropDownList ID="cboSexo" runat="server" class="form-control">
                        <asp:ListItem Value="Macho">Macho</asp:ListItem>
                        <asp:ListItem Value="Fêmea">Fêmea</asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class='col-sm-4'>
                    <div class="form-group">
                        <label for="usr">Data de Nascimento: </label>
                        <div class='input-group date'>
                            <asp:TextBox ID="txtNascimento" runat="server" class="form-control data" placeholder="00/00/0000" required></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Raça:</label>
                    <asp:DropDownList ID="cboRaca" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Especie:</label>
                    <asp:DropDownList ID="cboEspecie" runat="server" class="form-control">
                    </asp:DropDownList>
                </div>

                <div class="col-xs-12">
                    <label for="usr">Informações:</label>
                    <asp:TextBox ID="txtInformacoes" runat="server" Rows="6" class="form-control" TextMode="MultiLine"></asp:TextBox>
                </div>

                <div class="col-xs-7">
                    <label for="usr">Foto:</label>
                    <asp:FileUpload ID="arqFoto" runat="server" />
                </div>
            </div>

        <div class="separador"></div>

        <h2>
            <asp:Label ID="Label1" runat="server" Text="Cadastrar Responsável"></asp:Label></h2>
        <h4>Preencha todos os dados de Responsável corretamente.</h4>

        </br>

    <div class="row">

        <asp:Label ID="Label2" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

        <div class="col-xs-8">
            <label for="usr">Name:</label>
            <asp:TextBox ID="txtNomeResp" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">CPF:</label>
            <asp:TextBox ID="txtCPFResp" runat="server" class="form-control cpf" placeholder="000.000.000-00"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Telefone:</label>
            <asp:TextBox ID="txtTelefoneResp" runat="server" class="form-control telefone" placeholder="(xx) xxxx-xxxx"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Celular:</label>
            <asp:TextBox ID="txtCelularResp" runat="server" class="form-control telefone" placeholder="(xx) xxxxx-xxxx"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Email:</label>
            <asp:TextBox ID="txtEmailResp" runat="server" class="form-control" placeholder="nome@seuemail.com"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Endereço:</label>
            <asp:TextBox ID="txtEnderecoResp" runat="server" class="form-control" placeholder="Endereço completos"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Bairro:</label>
            <asp:TextBox ID="txtBairroResp" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Cidade:</label>
            <asp:TextBox ID="txtCidadeResp" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <label for="usr">Estado:</label>
            <asp:DropDownList ID="cboEstadoResp" runat="server" class="form-control">
                <asp:ListItem Value="RJ">Rio de janeiro</asp:ListItem>
                <asp:ListItem Value="SP">São paulo</asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

        <p></p>

        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-primary" OnClick="btnCadastrar_Click" />
        <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

    </form>
</asp:Content>

