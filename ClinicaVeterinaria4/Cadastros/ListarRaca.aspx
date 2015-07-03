<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarRaca.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarRaca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Raça</h1>
                <h4>Resumo de todas as raças cadastradas.</h4>
            </div>
        </div>

        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="upPesquisa" runat="server">
            <ContentTemplate>

                <div class="col-lg-16">
                    <div class="well well-sm">
                        <h4>Caixa de pesquisa</h4>
                        <div class="row">
                            <div class="col-xs-6">
                                <asp:TextBox ID="txtNome" runat="server" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
                                <asp:HiddenField ID="hiddenCodigo" runat="server" />
                            </div>

                            <div class="col-xs-4">
                                <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
                                <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Raça" class="btn btn-success" OnClick="btnCadastrar_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


        <asp:UpdatePanel ID="upGridRaca" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gridRaca" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                    OnRowCommand="gridRaca_RowCommand" DataKeyNames="cd_raca">
                    <Columns>
                        <asp:BoundField DataField="cd_raca" HeaderText="#" />
                        <asp:BoundField DataField="nm_raca" HeaderText="Nome" />
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label ID="lblStatus" runat="server" CssClass='<%# cssGrid(Eval("st_raca").ToString()) %>' Text='<%# Bind("st_raca") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30">
                            <HeaderStyle Width="30px" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" ShowInsertButton="True" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png">
                            <HeaderStyle Width="30px" />
                        </asp:CommandField>
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>


        <!-- Modal Excluir -->
        <div id="modalExcluir" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Excluir Raça</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir a Raça <b>
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


        <!-- Modal Alterar -->
        <div id="modalAlterar" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel2" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">Alterar Raça</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upAlterar" runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="form-group">

                                        <div class="col-sm-12">
                                            <label for="nomeRaca" class="control-label">Nome Raça:</label>
                                            <asp:TextBox ID="txtNomeModal" runat="server" class="form-control" placeholder="Nova Raça" autofocus></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnAlterar" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                        <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-success" OnClick="btnAlterar_Click" />
                    </div>

                </div>
            </div>
        </div>

    </form>

</asp:Content>
