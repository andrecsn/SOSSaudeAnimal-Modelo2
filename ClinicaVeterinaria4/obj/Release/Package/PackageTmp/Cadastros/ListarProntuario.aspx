<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarProntuario.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarProntuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Prontuário - Lista de Animal e Responsável</h1>
                <h4>Resumo de todos os animais e responsáveis cadastradas.</h4>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="well well-sm">
                    <h4>Caixa de pesquisa</h4>
                    <div class="row">

                        <div class="col-xs-4">
                            <asp:TextBox ID="txtAnimal" runat="server" OnTextChanged="btnPesquisar_Click" AutoPostBack="true" class="form-control" placeholder="Nome do Animal" autofocus></asp:TextBox>
                        </div>

                        <div class="col-xs-4">
                            <asp:TextBox ID="txtResponsavel" runat="server" OnTextChanged="btnPesquisar_Click" AutoPostBack="true" class="form-control" placeholder="Nome do Responsavel"></asp:TextBox>
                        </div>

                        <div class="col-xs-4">
                            <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
                            <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Animal / Responsável" class="btn btn-success" OnClick="btnCadastrar_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">

                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridProntuario" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridProntuario_RowCommand" DataKeyNames="cd_animal,cd_responsavel">
                            <Columns>
                                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                                <asp:BoundField DataField="nm_responsavel" HeaderText="Responsável" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/prontuario.png" HeaderText="Incluir" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtAnimal" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="txtResponsavel" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>

    </form>

</asp:Content>
