<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarEspecie.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarEspecie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Espécie</h2>
        <h4>Resumo de todas as espécies cadastradas.</h4>

        </br>


        <div class="col-xs-9">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
            <asp:HiddenField ID="hiddenCodigo" runat="server" />
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Espécie" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>

        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gridEspecie" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
                    OnRowCommand="gridEspecie_RowCommand" DataKeyNames="cod_especie">
                    <Columns>
                        <asp:BoundField DataField="cod_especie" HeaderText="#" />
                        <asp:BoundField DataField="nm_especie" HeaderText="Nome" />
                        <asp:BoundField DataField="st_especie" HeaderText="Status" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30" />
                        <asp:CommandField ButtonType="Image" ShowInsertButton="True" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" />
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
                        <h4 class="modal-title">Excluir Espécie</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir a espécie <b>
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
                        <h4 class="modal-title">Alterar Espécie</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upAlterar" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label for="lblnome" class="control-label">Nome Espécie:</label>
                                            <asp:TextBox ID="txtNomeModal" runat="server" class="form-control" placeholder="Nova Vacina" autofocus></asp:TextBox>
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
