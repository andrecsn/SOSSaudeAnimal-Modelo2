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
                        Lista de todas as consultas com Débitos financeiros
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
                                <asp:BoundField DataField="cd_animal" HeaderText="#" />
                                <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                                <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                                <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                                <asp:BoundField DataField="nm_responsavel" HeaderText="Responsável" />
                                <asp:BoundField DataField="celular" HeaderText="Celular" />
                                <asp:BoundField DataField="valor_debito" HeaderText="Saldo Devedor" DataFormatString="{0:C}" />
                                <asp:CommandField ButtonType="Image" NewImageUrl="~/App_Themes/Bootstrap/images/pagamento.png" ShowInsertButton="True">
                                    <HeaderStyle Width="50px" />
                                </asp:CommandField>
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/visualizar.png" ShowSelectButton="True" />
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
                                            <asp:TextBox ID="txtDinheiro" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="usr">C. Débito:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtDebito" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="usr">C. Crédito:</label>
                                        <div class="input-group">
                                            <div class="input-group-addon">R$</div>
                                            <asp:TextBox ID="txtCredito" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                        </div>
                                    </div>

                                </div>

                            </div>


                            <div class="modal-footer">
                                <span id="mensagemErro" style="color: #FF0000; font-size: medium; float: left; padding-top: 5px;"></span>
                                <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                                <asp:Button ID="btnCadastrarConsulta" runat="server" Text="Pagar" class="btn btn-success" OnClientClick="return verificaNulo()" OnClick="btnPagamento_Click" />
                            </div>

                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="btnCadastrarConsulta" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>


        <!-- Modal detalhe consulta -->
        <div id="detalheConsulta" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="gridSystemModalLabel2">Informações da Consulta</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upDetalheConsulta" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-5">
                                        <label for="usr">Data da Consulta</label>
                                        <h4><b>
                                            <asp:Label ID="lblDt_Consulta" runat="server"></asp:Label></b></h4>
                                    </div>

                                    <div class="col-xs-7">
                                        <label for="usr">Veterinária</label>
                                        <h4><b>
                                            <asp:Label ID="lblveterinaria" runat="server"></asp:Label></b></h4>
                                    </div>


                                    <table style="width: 100%;" class="table table-bordered">
                                        <tr class="active">
                                            <td colspan="4"><b>Descrição do Atendimento</b></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblDsConsulta" runat="server"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td><b>Consulta:</b></td>
                                            <td>
                                                <asp:Label ID="lblValorConsulta" runat="server"></asp:Label></td>
                                            <td><b>Valor Cirurgia:</b></td>
                                            <td>
                                                <asp:Label ID="lblValorCirurgia" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td><b>Valor Soroterapia:</b></td>
                                            <td>
                                                <asp:Label ID="lblValorSoroterapia" runat="server"></asp:Label>
                                            </td>
                                            <td><b>Valor tartarectomia:</b></td>
                                            <td>
                                                <asp:Label ID="lblValortartarectomia" runat="server"></asp:Label>
                                            </td>
                                            <tr>
                                                <td><b>Valor Medicamentos:</b></td>
                                                <td>
                                                    <asp:Label ID="lblValorMedicamentos" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <b>Valor Vacinas:</b></td>
                                                <td>
                                                    <asp:Label ID="lblValorVacinas" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Outros:</b></td>
                                                <td>
                                                    <asp:Label ID="lblValorOutros" runat="server"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblDescricaoOutros" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Exame:</b></td>
                                                <td>
                                                    <asp:Label ID="lblValorExame" runat="server"></asp:Label></td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblDescricaoExame" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td><b>Vendas:</b></td>
                                                <td>
                                                    <asp:Label ID="lblValorVendas" runat="server"></asp:Label></td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblDescricaoVendas" runat="server"></asp:Label></td>
                                            </tr>
                                        </tr>
                                    </table>



                                    <table style="width: 100%;" class="table table-bordered">
                                        <tr class="active">
                                            <td colspan="5"><b>Descrição do pagamento</b></td>
                                        </tr>
                                        <tr>
                                            <td><b>Dinheiro:</b></td>
                                            <td><b>C.Débito:</b></td>
                                            <td><b>C. Crédito:</b></td>
                                            <td><b>Total:</b></td>
                                            <td><b>Saldo Devedor:</b></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblValorDinheiro" runat="server"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblValorDebito" runat="server"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblValorCredito" runat="server"></asp:Label>
                                            </td>
                                            <td class="success"><b>
                                                <asp:Label ID="lblTotalModal" runat="server"></asp:Label>
                                            </b></td>
                                            <td class="danger">
                                                <b>
                                                    <asp:Label ID="lblSaldoDevedor" runat="server"></asp:Label>
                                                </b></td>
                                        </tr>
                                    </table>

                                </div>

                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-success" data-dismiss="modal">Fechar</button>
                    </div>

                </div>
            </div>
        </div>

    </form>


    <script type="text/javascript">

        function verificaNulo() {

            var dinheiro = document.getElementById("Corpo_txtDinheiro").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtDinheiro").value);
            var credito = document.getElementById("Corpo_txtCredito").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtCredito").value);
            var debito = document.getElementById("Corpo_txtDebito").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtDebito").value);
            var total = document.getElementById("Corpo_HiddenSaldoDevedor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_HiddenSaldoDevedor").value);

            var pagar = parseFloat(dinheiro + debito + credito);

            if (dinheiro == "" && credito == "" && debito == "") {
                document.getElementById("mensagemErro").innerHTML = "Preencha uma forma de Pagamento!";
                document.getElementById("Corpo_txtDinheiro").focus();
                return false;
            } else if (pagar > total) {
                document.getElementById("mensagemErro").innerHTML = "Pagamento maior que o saldo devedor! R$ " + pagar;
                return false;
            } else {
                return true;
            }
        }
    </script>

</asp:Content>
