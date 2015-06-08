<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroEspecie.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.especie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2><asp:Label ID="lblTitulo" runat="server" Text="Cadastrar Espécie"></asp:Label></h2>
        <h4>Preencha todos os dados de Especie corretamente.</h4>

        </br>

        <div class="row">

            <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

            <div class="col-xs-7">
                <label for="usr">Name da Espécie:</label>
                <asp:TextBox ID="txtEspecie" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                <asp:Label ID="lblEspecie" runat="server" Text="" Visible="False"></asp:Label>
            </div>

            <div class="col-xs-5">
                <label class="control-label" for="radios">Status: </label>
                <div class="controls">
                    <asp:RadioButtonList ID="listStatus" runat="server" CellPadding="5" CellSpacing="5" RepeatDirection="Horizontal" Width="150">
                        <asp:ListItem Text="Ativo" Value="Ativo" Selected="True"></asp:ListItem>
                        <asp:ListItem Text="Inativo" Value="Inativo"></asp:ListItem>
                    </asp:RadioButtonList>
                </div>
                <asp:Label ID="lblStatus" runat="server" Text="" Visible="False"></asp:Label>
            </div>
        </div>

        <p></p>
        <p></p>

        <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-primary" OnClick="btnCadastrar_Click" />
        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-primary" OnClick="btnAlterar_Click" Visible="False" />
        <asp:Button ID="btnExcluir" runat="server" Text="Excluir" class="btn btn-danger" OnClick="btnExcluir_Click" Visible="False" />
        <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

    </form>
</asp:Content>
