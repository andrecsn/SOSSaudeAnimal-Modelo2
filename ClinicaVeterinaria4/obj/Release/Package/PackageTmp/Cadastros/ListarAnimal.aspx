<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarAnimal.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarAnimal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Animal e Responsável</h2>
        <h4>Resumo de todos os animais e responsáveis cadastradas.</h4>

        </br>


        <div class="col-xs-4">
            <asp:TextBox ID="txtAnimal" runat="server" Columns="50" class="form-control" placeholder="Nome do Animal" autofocus></asp:TextBox>
        </div>

        <div class="col-xs-4">
            <asp:TextBox ID="txtResponsavel" runat="server" Columns="50" class="form-control" placeholder="Nome do Responsavel"></asp:TextBox>
        </div>

        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Animal / Responsável" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_animal, cd_responsavel">
            <Columns>
                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                <asp:BoundField DataField="nm_responsavel" HeaderText="Responsável" />
                <asp:BoundField DataField="celular" HeaderText="Celular" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" EditImageUrl="~/App_Themes/Bootstrap/images/animal.png" ControlStyle-Width="22" ControlStyle-Height="22" ShowEditButton="True" ></asp:CommandField>
                <asp:CommandField ButtonType="Image" ControlStyle-Width="22" ControlStyle-Height="22" ShowInsertButton="True" NewImageUrl="~/App_Themes/Bootstrap/images/vacina.png" ></asp:CommandField>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </form>

</asp:Content>
