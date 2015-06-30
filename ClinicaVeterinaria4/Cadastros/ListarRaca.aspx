<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarRaca.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarRaca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h2>Lista de Raça</h2>
        <h4>Resumo de todas as raças cadastradas.</h4>

        </br>

        <div class="col-xs-9">
            <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Caixa de pesquisa" autofocus></asp:TextBox>
        </div>


        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-primary" OnClick="btnPesquisar_Click" />
        <asp:Button ID="btCadastrar" runat="server" Text="Cadastrar Raça" class="btn btn-success" OnClick="btnCadastrar_Click" />


        <div class="separador"></div>

        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="upGridRaca" runat="server">
            <ContentTemplate>

                <asp:GridView ID="gridRaca" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
                    OnRowCommand="gridRaca_RowCommand" DataKeyNames="cd_raca">
                    <Columns>
                        <asp:BoundField DataField="cd_raca" HeaderText="#" />
                        <asp:BoundField DataField="nm_raca" HeaderText="Nome" />
                        <asp:BoundField DataField="st_raca" HeaderText="Status" />
                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30">
                            <HeaderStyle Width="30px" />
                        </asp:CommandField>
                        <asp:CommandField ButtonType="Image" ShowInsertButton="True" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" />
                    </Columns>
                </asp:GridView>

            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>


        <!-- Modal de pagamento -->
        <div id="excluirRaca" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="gridSystemModalLabel">Excluir Raça</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluirRaca" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                             <h4>Deseja mesmo excluir a Raça <b><asp:Label ID="lblNomeRaca" runat="server"></asp:Label></b> ?
                                        </div>

                                        <asp:HiddenField ID="hiddenCodigo" runat="server" />
                                    </div>

                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnExcluir" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                            <asp:Button ID="btnExcluir" runat="server" Text="Confirmar" class="btn btn-danger" OnClick="btnExcluir_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

    </form>

</asp:Content>
