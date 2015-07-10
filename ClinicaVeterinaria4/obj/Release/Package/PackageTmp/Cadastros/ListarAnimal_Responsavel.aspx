<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarAnimal_Responsavel.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarAnimal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Animal e Responsável</h1>
                <h4>Resumo de todos os animais e responsáveis cadastradas.</h4>
            </div>
        </div>


        <div class="col-lg-12">
            <div class="well well-sm">
                <h4>Caixa de pesquisa</h4>
                <div class="row">
                    <div class="col-xs-4">
                        <asp:TextBox ID="txtAnimal" runat="server" OnTextChanged="btnPesquisar_Click" AutoPostBack="true" class="form-control" placeholder="Nome do Animal" autofocus></asp:TextBox>
                        <asp:HiddenField ID="hiddenCodigo" runat="server" />
                    </div>

                    <div class="col-xs-4">
                        <asp:TextBox ID="txtResponsavel" runat="server" OnTextChanged="btnPesquisar_Click" AutoPostBack="true" class="form-control" placeholder="Nome do Responsavel"></asp:TextBox>
                    </div>

                    <div class="col-xs-4">
                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
                        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar" class="btn btn-success" OnClick="btnCadastrar_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">

                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_animal,cd_responsavel">
                            <Columns>
                                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                                <asp:BoundField DataField="nm_responsavel" HeaderText="Responsável" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30">
                                    <HeaderStyle Width="30px" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" EditImageUrl="~/App_Themes/Bootstrap/images/animal.png" ControlStyle-Width="22" ControlStyle-Height="22" ShowEditButton="True" HeaderStyle-Width="30">
                                    <ControlStyle Height="22px" Width="22px" />
                                    <HeaderStyle Width="30px" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/vacina.png" ShowDeleteButton="True">
                                    <ControlStyle Height="22px" Width="22px" />
                                    <HeaderStyle Width="30px" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowInsertButton="True">
                                    <HeaderStyle Width="30px" />
                                </asp:CommandField>
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



        <!-- Modal Excluir -->
        <div id="modalExcluir" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="gridSystemModalLabel1">Excluir Animal</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir o animal <b>
                                                <asp:Label ID="lblNomeModal" runat="server"></asp:Label></b>
                                            ?
                                        </div>

                                    </div>

                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnExcluir" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnExcluir" runat="server" Text="Confirmar" class="btn btn-danger" OnClick="btnExcluir_Click" />
                    </div>

                </div>
            </div>
        </div>


    </form>

</asp:Content>
