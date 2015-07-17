<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Site1.Master" AutoEventWireup="true" CodeBehind="ListarVacina.aspx.cs" Inherits="ClinicaVeterinaria.Presentation.ListarVacina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Vacina</h1>
                <h4>Resumo de todas as vacina cadastradas.</h4>
            </div>
        </div>

        <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="upPesquisa" runat="server">
            <ContentTemplate>

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
                                <asp:Button ID="btCadastrarModal" runat="server" Text="Cadastrar Vacina" class="btn btn-success" OnClick="btnCadastrarModal_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click" />
                <asp:AsyncPostBackTrigger ControlID="btCadastrarModal" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>


        <div class="row">
            <div class="col-lg-12">

                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridVacina_RowCommand" DataKeyNames="cd_vacina">
                            <Columns>
                                <asp:BoundField DataField="cd_vacina" HeaderText="#" />
                                <asp:BoundField DataField="nm_vacina" HeaderText="Nome" />
                                <asp:BoundField DataField="valor" HeaderText="Valor" DataFormatString="{0:C}" />
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" CssClass='<%# cssGrid(Eval("st_vacina").ToString()) %>' Text='<%# Bind("st_vacina") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30">
                                    <HeaderStyle Width="30px" />
                                </asp:CommandField>
                                <asp:TemplateField HeaderStyle-Width="45" ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgDelete" runat="server" CausesValidation="False" CommandName="Deletar" ImageUrl="~/App_Themes/Bootstrap/images/delete.png" OnClick="imgDelete_Click" Visible='<%# delete() %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="txtNome" EventName="TextChanged" />
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
                        <h4 class="modal-title">Excluir Vacina</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir a vacina <b>
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


        <!-- Modal Alterar Incluir -->
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

                                    <div class="col-sm-8">
                                        <div class="form-group">
                                            <label for="lblnome" class="control-label">Nome Raça:</label>
                                            <asp:TextBox ID="txtNomeModal" runat="server" class="form-control" placeholder="Nova Vacina" autofocus></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="lblValor">Valor:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtValorModal" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
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
