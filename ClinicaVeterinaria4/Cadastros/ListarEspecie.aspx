<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarEspecie.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarEspecie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Espécie</h1>
                <h4>Resumo de todas as espécies cadastradas.</h4>
            </div>
        </div>


        <div class="col-lg-16">
            <div class="well well-sm">
                <h4>Caixa de pesquisa</h4>
                <div class="row">
                    <div class="col-xs-6">
                        <asp:TextBox ID="txtNome" runat="server" OnTextChanged="btnPesquisar_Click" AutoPostBack="true" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
                        <asp:HiddenField ID="hiddenCodigo" runat="server" />
                    </div>

                    <div class="col-xs-4">
                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
                        <asp:Button ID="btCadastrarModal" runat="server" Text="Cadastrar Espécie" class="btn btn-success" OnClick="btnCadastrarModal_Click" />
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridEspecie" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridEspecie_RowCommand" DataKeyNames="cod_especie">
                            <Columns>
                                <asp:BoundField DataField="cod_especie" HeaderText="#" />
                                <asp:BoundField DataField="nm_especie" HeaderText="Nome" />
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRaca" runat="server" CssClass='<%# cssGrid(Eval("st_especie").ToString()) %>' Text='<%# Bind("st_especie") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30" />
                                <asp:CommandField ButtonType="Image" ShowInsertButton="True" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtNome" EventName="TextChanged" />
                        <asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btCadastrarModal" EventName="Click" />
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


        <!-- Modal Alterar e Incluir -->
        <div id="modalAlterarIncluir" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel2" aria-hidden="true">
            <div class="modal-dialog modal-md">

                <asp:UpdatePanel ID="upAlterarIncluir" runat="server">
                    <ContentTemplate>

                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title">
                                    <asp:Label ID="lblTituloModal" runat="server"></asp:Label></h4>
                            </div>

                            <div class="modal-body">
                                <div class="row">

                                    <div class="col-sm-12">
                                        <div class="form-group">
                                            <label for="lblnome" class="control-label">Nome Espécie:</label>
                                            <asp:TextBox ID="txtNomeModal" runat="server" class="form-control" placeholder="Nova Espécie" autofocus></asp:TextBox>
                                        </div>
                                    </div>

                                </div>
                            </div>

                            <div class="modal-footer">
                                <span id="mensagemErro" style="color: #FF0000; font-size: medium; float: left; padding-top: 5px;"></span>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Cancelar</button>
                                <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-success" Visible="false" OnClick="btnAlterar_Click" />
                                <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-success" Visible="false" OnClientClick="return verificaNulo()" OnClick="btnIncluir_Click" />
                            </div>

                        </div>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnAlterar" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="btnCadastrar" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>


        <script type="text/javascript">
            function verificaNulo() {

                if (document.getElementById("Corpo_txtNomeModal").value == "") {
                    document.getElementById("mensagemErro").innerHTML = "Preencha o campo nome!";
                    document.getElementById("Corpo_txtNomeModal").focus();
                    return false;
                } else {
                    return true;
                }
            }
        </script>


    </form>

</asp:Content>
