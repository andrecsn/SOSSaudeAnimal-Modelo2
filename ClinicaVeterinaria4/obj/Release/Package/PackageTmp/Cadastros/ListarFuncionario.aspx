<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarFuncionario.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Funcionários</h2>
        <h4>Resumo de todos os funcionários cadastrados.</h4>

        </br>


        <div class="col-xs-8">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Funcionário" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridFuncionario" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None" 
            OnRowCommand="gridFuncionario_RowCommand" DataKeyNames="cd_funcionario">
            <Columns>
                <asp:BoundField DataField="cd_funcionario" HeaderText="#" />
                <asp:BoundField DataField="nm_funcionario" HeaderText="Nome" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="celular" HeaderText="Celular" />
                <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


    </form>

</asp:Content>
