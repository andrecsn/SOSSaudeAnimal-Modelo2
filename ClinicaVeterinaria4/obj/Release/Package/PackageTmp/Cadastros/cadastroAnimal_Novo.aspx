<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroAnimal_Novo.aspx.cs" Inherits="ClinicaVeterinaria.cadastroAnimal_Novo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h4>Dados do Responsável do animal.</h4>

        </br>

    <div class="row">

        <asp:Label ID="lblCodigoResp" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

        <div class="col-xs-6">
            <label for="usr">Nome:</label>
            <asp:TextBox ID="txtNomeResp" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
            <asp:Label ID="lblNomeResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-6">
            <label for="usr">CPF:</label>
            <asp:TextBox ID="txtCPFResp" runat="server" class="form-control" placeholder="000.000.000-00"></asp:TextBox>
            <asp:Label ID="lblCPFResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-3">
            <label for="usr">Telefone:</label>
            <asp:TextBox ID="txtTelefoneResp" runat="server" class="form-control" placeholder="(xx) xxxx-xxxx" required></asp:TextBox>
            <asp:Label ID="lblTelefoneResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-3">
            <label for="usr">Celular:</label>
            <asp:TextBox ID="txtCelularResp" runat="server" class="form-control" placeholder="(xx) xxxxx-xxxx"></asp:TextBox>
            <asp:Label ID="lblCelularResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-6">
            <label for="usr">Email:</label>
            <asp:TextBox ID="txtEmailResp" runat="server" class="form-control" placeholder="nome@seuemail.com"></asp:TextBox>
            <asp:Label ID="lblEmailResp" runat="server" Text="Label" Visible="False"></asp:Label>
        </div>

        <div class="col-xs-6">
            <label for="usr">Endereço:</label>
            <asp:TextBox ID="txtEnderecoResp" runat="server" class="form-control" placeholder="Endereço completos"></asp:TextBox>
            <asp:Label ID="lblEnderecoResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-2">
            <label for="usr">Bairro:</label>
            <asp:TextBox ID="txtBairroResp" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="lblBairroResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Cidade:</label>
            <asp:TextBox ID="txtCidadeResp" runat="server" class="form-control"></asp:TextBox>
            <asp:Label ID="lblCidadeResp" runat="server" Visible="false"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Estado:</label>
            <asp:DropDownList ID="cboEstadoResp" runat="server" class="form-control">
                <asp:ListItem Value="RJ">Rio de janeiro</asp:ListItem>
                <asp:ListItem Value="SP">São paulo</asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="lblEstadoResp" runat="server" Visible="false"></asp:Label>
        </div>

    </div>

        <div class="separador"></div>

        <h4>Outros Animais desse responsável.</h4>
        </br>

        <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_animal, cd_responsavel">
            <Columns>
                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                <asp:BoundField DataField="inf_animal" HeaderText="informações" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


        <div class="separador"></div>

        <h2>
            <asp:Label ID="lblTitulo" runat="server" Text="Dados do novo animal"></asp:Label></h2>
        <h4>Preencha todos os dados de Animal corretamente.</h4>

        </br>


            <div class="row">

                <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                <div class="col-xs-8">
                    <label for="usr">Name:</label>
                    <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                    <asp:Label ID="lblNome" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Pelagem:</label>
                    <asp:TextBox ID="txtCor" runat="server" class="form-control" required></asp:TextBox>
                    <asp:Label ID="lblCor" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Peso:</label>
                    <asp:TextBox ID="txtPeso" runat="server" class="form-control" placeholder="Ex.: 10gr" required></asp:TextBox>
                    <asp:Label ID="lblPeso" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Data de Nascimento:</label>
                    <asp:TextBox ID="txtNascimento" runat="server" class="form-control" placeholder="00/00/0000" required></asp:TextBox>
                    <asp:Label ID="lblNascimento" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Sexo:</label>
                    <asp:DropDownList ID="cboSexo" runat="server" class="form-control">
                        <asp:ListItem Value="Macho">Macho</asp:ListItem>
                        <asp:ListItem Value="Fêmea">Fêmea</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="lblSexo" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Raça:</label>
                    <asp:DropDownList ID="cboRaca" runat="server" class="form-control">
                    </asp:DropDownList>
                    <asp:Label ID="lblraca" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Especie:</label>
                    <asp:DropDownList ID="cboEspecie" runat="server" class="form-control">
                    </asp:DropDownList>
                    <asp:Label ID="lblEspecie" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-12">
                    <label for="usr">Informações:</label>
                    <asp:TextBox ID="txtInformacoes" runat="server" Rows="6" class="form-control" TextMode="MultiLine"></asp:TextBox>
                    <asp:Label ID="lblInformacoes" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>

                <div class="col-xs-7">
                    <label for="usr">Foto:</label>
                    <asp:FileUpload ID="arqFoto" runat="server" />
                    <asp:Label ID="lblFoto" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>



        <p></p>

        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-primary" OnClick="btnCadastrar_Click" />
        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-primary" OnClick="btnAlterar_Click" Visible="False" />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-danger" OnClick="btnExcluir_Click" Visible="False" />
        <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

    </form>
</asp:Content>

