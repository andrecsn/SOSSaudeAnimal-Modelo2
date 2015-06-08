<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarHistVacina.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.CadastrarHistVacina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Cadastrar Histórico de Vacinas</h2>
        <h4>Resumo de todas os históricos de vacina cadastradas.</h4>

        </br>


        <div class="col-xs-9">
            <asp:TextBox ID="txtCodigoAnimal" runat="server" Columns="50" class="form-control" placeholder="Digite o código do animal" autofocus></asp:TextBox>
        </div>

        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />

        <div class="separador"></div>

        <asp:Label ID="lblMensagem" runat="server" Text="" Visible="False"></asp:Label>

        <div class="col-xs-9">
            <asp:Label ID="lblTituloAnimal" runat="server" Text="" Font-Bold="True">Nome Animal: </asp:Label>
            <asp:Label ID="lblAnimal" runat="server" Text="" Visible="False"></asp:Label>
        </div>

        <div class="col-xs-9">
            <asp:Label ID="lblTituloResponsavel" runat="server" Text="" Font-Bold="True">Nome do Responsavél: </asp:Label>
            <asp:Label ID="lblResponsavel" runat="server" Text="" Visible="False"></asp:Label>
        </div>

        <p>&nbsp</p>
        </br>

        <div class="col-xs-5">
            <asp:Label ID="lblTituloVacina" runat="server" Text="" Visible="false" Font-Bold="True">Vacina: </asp:Label>
            <asp:DropDownList ID="cboVacina" runat="server" class="form-control" Visible="false">
            </asp:DropDownList>
        </div>

        <div class="col-xs-2">
            <asp:Label ID="lblTituloAplicacao" runat="server" Text="" Visible="false" Font-Bold="True">Data de Aplicação: </asp:Label>
            <asp:TextBox ID="txtDt_aplicacao" runat="server" class="form-control" placeholder="00/00/0000" Visible="false" required></asp:TextBox>
        </div>

        <div class="col-xs-3">
            <asp:Label ID="lblTituloVencimento" runat="server" Text="" Visible="false" Font-Bold="True">Data de vencimento: </asp:Label>
            <asp:TextBox ID="txtDt_vencimento" runat="server" class="form-control" placeholder="00/00/0000" Visible="false" required></asp:TextBox>
        </div>

        <asp:Button ID="btnCadastrar" runat="server" Text="Incluir Vacina" class="btn btn-primary" Visible="false" OnClick="btnCadastrar_Click" />

        <p>&nbsp</p>
        </br>

        <asp:GridView ID="gridHistVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None">
            <Columns>
                <asp:BoundField DataField="cd_hist_vacina" HeaderText="#" />
                <asp:BoundField DataField="vacina.nm_vacina" HeaderText="Vacina" />
                <asp:BoundField DataField="dt_hist_vacina" HeaderText="Data de Aplicação" />
                <asp:BoundField DataField="dt_vencimento" HeaderText="Venvimento da vacina" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>


    </form>

</asp:Content>
