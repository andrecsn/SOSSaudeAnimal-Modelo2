<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarAnimal.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarAnimal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Animal</h2>
        <h4>Resumo de todos os animais cadastradas.</h4>

        </br>


        <div class="col-xs-8">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Animal" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_animal">
            <Columns>
                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                <asp:BoundField DataField="dt_nascimento" HeaderText="Data de Nascimento" />
                <asp:BoundField DataField="inf_animal" HeaderText="informações" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


    </form>

</asp:Content>
