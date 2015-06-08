<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarResponsavel.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.listarResponsavel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Responsável</h2>
        <h4>Resumo de todas os resposáveis cadastradas.</h4>

        </br>


        <div class="col-xs-8">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Responsável" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridResponsavel" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridResponsavel_RowCommand" DataKeyNames="cd_responsavel">
            <Columns>
                <asp:BoundField DataField="cd_responsavel" HeaderText="#" />
                <asp:BoundField DataField="nm_responsavel" HeaderText="Nome" />
                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                <asp:BoundField DataField="celular" HeaderText="Celular" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


    </form>

</asp:Content>
