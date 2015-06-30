<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarEspecie.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarEspecie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Espécie</h2>
        <h4>Resumo de todas as espécies cadastradas.</h4>

        </br>


        <div class="col-xs-9">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Espécie" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridEspecie" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridEspecie_RowCommand" DataKeyNames="cod_especie">
            <Columns>
                <asp:BoundField DataField="cod_especie" HeaderText="#" />
                <asp:BoundField DataField="nm_especie" HeaderText="Nome" />
                <asp:BoundField DataField="st_especie" HeaderText="Status" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" HeaderStyle-Width="30" />
            </Columns>
        </asp:GridView>

    </form>

</asp:Content>
