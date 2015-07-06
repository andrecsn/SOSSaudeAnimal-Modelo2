<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarFuncionario.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarFuncionario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Lista de Funcionários</h1>
                <h4>Resumo de todos os funcionários cadastrados.</h4>
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
                        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Funcionário" class="btn btn-success" OnClick="btnCadastrar_Click" />
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">

                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGridRaca" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridFuncionario" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridFuncionario_RowCommand" DataKeyNames="cd_funcionario">
                            <Columns>
                                <asp:BoundField DataField="cd_funcionario" HeaderText="#" />
                                <asp:BoundField DataField="nm_funcionario" HeaderText="Nome" />
                                <asp:BoundField DataField="cpf" HeaderText="CPF" />
                                <asp:BoundField DataField="telefone" HeaderText="Telefone" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:TemplateField HeaderText="Tipo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTipo" runat="server" CssClass='<%# cssGrid(Eval("tipo").ToString()) %>' Text='<%# Bind("tipo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30" />
                                <asp:CommandField ButtonType="Image" ShowInsertButton="True" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" HeaderStyle-Width="30" />
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
                        <h4 class="modal-title" id="gridSystemModalLabel1">Excluir Funcionário</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluirRaca" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir o funcionário <b>
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
