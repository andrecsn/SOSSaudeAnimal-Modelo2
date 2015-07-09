<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="ListarDebito.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.ListarDebito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">


    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Relatório de Débitos</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-red">
                    <div class="panel-heading">
                        Red Panel
                       
                    </div>
                    <div class="panel-body">

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
                            </div>

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

                        <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                            OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_consulta">
                            <Columns>
                                <asp:BoundField DataField="cd_consulta" Visible="true" />
                                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                                <asp:BoundField DataField="nm_responsavel" HeaderText="Responsável" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:BoundField DataField="valor_debito" HeaderText="Saldo Devedor" DataFormatString="{0:C}" />
                                <asp:CommandField ButtonType="Image" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowInsertButton="True">
                                    <HeaderStyle Width="50px" />
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





        <!-- Modal de pagamento -->
        <div id="pagamento" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">

                    <asp:UpdatePanel ID="upPagamento" runat="server">
                        <ContentTemplate>

                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                                <h4 class="modal-title" id="gridSystemModalLabel">Formas de pagamento <b>- R$ 
                            <asp:Label ID="lblSaldoDevetor" Text="0" runat="server"></asp:Label>
                                    <asp:HiddenField ID="HiddenSaldoDevedor" runat="server" />
                                    <asp:HiddenField ID="HiddenConsulta" runat="server" />
                                </b></h4>
                            </div>

                            <div class="modal-body">
                                <div class="row">

                                    <div class="col-xs-4">
                                        <label for="usr">Dinheiro:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtDinheiro" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)" autofocus></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="usr">C. Crédito:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtCredito" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="usr">C. Débito:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtDebito" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                            </div>


                            <div class="modal-footer">
                                <span id="mensagemErro" style="color: #FF0000; font-size: medium; float: left; padding-top: 5px;"></span>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                                <asp:Button ID="btnCadastrarConsulta" runat="server" Text="Realizar Pagamento" class="btn btn-success" OnClientClick="return verificaNulo()" OnClick="btnPagamento_Click" />
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCadastrarConsulta" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>


    </form>


</asp:Content>
