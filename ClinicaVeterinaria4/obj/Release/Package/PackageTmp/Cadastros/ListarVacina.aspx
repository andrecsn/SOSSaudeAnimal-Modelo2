<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarVacina.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarVacina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Vacina</h2>
        <h4>Resumo de todas as vacina cadastradas.</h4>

        </br>


        <div class="col-xs-9">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Vacina" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>


        <asp:GridView ID="gridVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridVacina_RowCommand" DataKeyNames="cd_vacina">
            <Columns>
                <asp:BoundField DataField="cd_vacina" HeaderText="#" />
                <asp:BoundField DataField="nm_vacina" HeaderText="Nome" />
                <asp:BoundField DataField="valor" HeaderText="Valor" DataFormatString="{0:C}"/>
                <asp:BoundField DataField="st_vacina" HeaderText="Status" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30"/>
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" HeaderStyle-Width="30" />
            </Columns>
        </asp:GridView>
    </form>

</asp:Content>
