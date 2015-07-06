<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastrarHistVacina.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.CadastrarHistVacina" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Cadastrar Histórico de Vacinas</h1>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Resumo de todas os históricos de vacina cadastradas</b></div>
                    <div class="panel-body">

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="well well-sm">

                                    <div class="form-group">
                                        <asp:Label ID="lblTituloAnimal" runat="server" Text="" Font-Bold="True">Nome Animal: </asp:Label>
                                        <asp:Label ID="lblAnimal" runat="server"></asp:Label>
                                    </div>

                                    <div class="form-group">
                                        <asp:Label ID="lblTituloResponsavel" runat="server" Text="" Font-Bold="True">Nome do Responsavél: </asp:Label>
                                        <asp:Label ID="lblResponsavel" runat="server"></asp:Label>
                                    </div>

                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-12">
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>Vacina: </label>
                                        <asp:DropDownList ID="cboVacina" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class='col-lg-3'>
                                    <div class="form-group">
                                        <label>Data de Aplicação: </label>
                                        <div class='input-group date'>
                                            <asp:TextBox ID="txtDt_aplicacao" runat="server" class="form-control data" required></asp:TextBox>
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class='col-lg-3'>
                                    <div class="form-group">
                                        <label>Revacinar: </label>
                                        <div class='input-group date'>
                                            <asp:TextBox ID="txtDt_vencimento" runat="server" class="form-control data" required></asp:TextBox>
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-3">
                                    <div class="form-group">
                                        </br>
                                        <asp:Button ID="btnCadastrar" runat="server" Text="Incluir Vacina" class="btn btn-primary" OnClick="btnCadastrar_Click" />
                                        <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">

                <asp:ScriptManager ID="ScriptManager" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGrid" runat="server">
                    <ContentTemplate>

                        <asp:GridView ID="gridHistVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridHistVacina_RowCommand" DataKeyNames="cd_hist_vacina">
                            <Columns>
                                <asp:BoundField DataField="cd_hist_vacina" HeaderText="#" />
                                <asp:BoundField DataField="nm_vacina" HeaderText="Vacina" />
                                <asp:BoundField DataField="dt_hist_vacina" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Data de Aplicação" />
                                <asp:BoundField DataField="dt_vencimento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Revacinar" />
                                <asp:BoundField DataField="nm_funcionario" HeaderText="Veterinária" />
                                <asp:CommandField ButtonType="Image" HeaderStyle-Width="30" SelectImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>

                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnCadastrar" EventName="Click" />
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
                        <h4 class="modal-title">Excluir Histórico de Vacinas</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir a vacina <b>
                                                <asp:Label ID="lblNomeModal" runat="server"></asp:Label></b>
                                            do histórico?
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
