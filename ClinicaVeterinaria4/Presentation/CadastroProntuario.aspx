<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroProntuario.aspx.cs" Inherits="ClinicaVeterinaria.Presentation.cadastroProntuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Prontuário do animal</h1>
            </div>
        </div>

        <!-- Dados do animal -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados do Animal</b></div>
                    <div class="panel-body">

                        <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Nome:</label>
                                <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Pelagem:</label>
                                <asp:Label ID="lblCor" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Peso:</label>
                                <asp:Label ID="lblPeso" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Informações:</label>
                                <asp:Label ID="lblInformacoes" runat="server" Text="Label"></asp:Label>
                            </div>

                        </div>


                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Data de Nascimento:</label>
                                <asp:Label ID="lblNascimento" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Sexo:</label>
                                <asp:Label ID="lblSexo" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Raça:</label>
                                <asp:Label ID="lblraca" runat="server" Text="Label"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Especie:</label>
                                <asp:Label ID="lblEspecie" runat="server" Text="Label"></asp:Label>
                            </div>

                        </div>

                        <div class="col-lg-4 text-center img-responsive">

                            <asp:Image ID="foto" runat="server" ImageUrl="~/App_Themes/Bootstrap/images/sem-foto.jpg" Height="150" Width="150" CssClass="img-circle" />

                        </div>

                    </div>
                </div>
            </div>
        </div>

        <!-- Dados do resposável -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados do Responsável</b></div>
                    <div class="panel-body">

                        <asp:Label ID="lblCodigoResp" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Nome:</label>
                                <asp:Label ID="lblNomeResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">CPF:</label>
                                <asp:Label ID="lblCPFResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Email:</label>
                                <asp:Label ID="lblEmailResp" runat="server"></asp:Label>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Telefone:</label>
                                <asp:Label ID="lblTelefoneResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Celular:</label>
                                <asp:Label ID="lblCelularResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Endereço:</label>
                                <asp:Label ID="lblEnderecoResp" runat="server"></asp:Label>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Bairro:</label>
                                <asp:Label ID="lblBairroResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Cidade:</label>
                                <asp:Label ID="lblCidadeResp" runat="server"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Estado:</label>
                                <asp:Label ID="lblEstadoResp" runat="server"></asp:Label>
                            </div>

                        </div>

                    </div>
                </div>
            </div>
        </div>


        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>


        <!-- Aplicação e Histórico de Vacinas -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Aplicação e Histórico de Vacinas</b></div>
                    <div class="panel-body">

                        <div class="col-lg-16">
                            <div class="well well-sm">
                                <div class="row">

                                    <div class="col-xs-4">
                                        <label for="usr">Vacina: </label>
                                        <asp:DropDownList ID="cboVacina" runat="server" class="form-control">
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-xs-3">
                                        <label for="usr">Data de Aplicação: </label>
                                        <asp:TextBox ID="txtDt_aplicacao" runat="server" class="form-control" disabled></asp:TextBox>
                                    </div>

                                    <div class='col-sm-3'>
                                        <div class="form-group">
                                            <label for="usr">Revacinar: </label>
                                            <div class='input-group date'>
                                                <asp:TextBox ID="txtDt_vencimento" runat="server" class="form-control data" required></asp:TextBox>
                                                <span class="input-group-addon">
                                                    <span class="glyphicon glyphicon-calendar"></span>
                                                </span>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-xs-2">
                                        <br>
                                        <asp:Button ID="btnCadastrarVacina" runat="server" Text="Incluir Vacina" class="btn btn-primary" OnClick="btnCadastrarVacina_Click" />
                                    </div>

                                </div>
                            </div>
                        </div>

                        <asp:UpdatePanel ID="upVacinas" runat="server">
                            <ContentTemplate>

                                <asp:GridView ID="gridVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="cd_hist_vacina" HeaderText="#" />
                                        <asp:BoundField DataField="nm_vacina" HeaderText="Vacina" />
                                        <asp:BoundField DataField="dt_hist_vacina" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Data de Aplicação" />
                                        <asp:BoundField DataField="dt_vencimento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Revacinar" />
                                        <asp:BoundField DataField="nm_funcionario" HeaderText="Veterinário" />
                                    </Columns>
                                </asp:GridView>


                                <div class="row">
                                    <div class="col-md-8"></div>
                                    <div class="col-md-2"><b>Valor Vacinas: </b></div>
                                    <div class="col-md-2">
                                        <b>
                                            <asp:Label ID="lblTotalVacinas" runat="server"></asp:Label></b>
                                        <asp:HiddenField ID="hiddenVacinas" runat="server" Value="0" />
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCadastrarVacina" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>

        <!-- Descrição do atendimento -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Descrição do Atendimento</b></div>
                    <div class="panel-body">

                        <asp:UpdatePanel ID="upAtendimento" runat="server">
                            <ContentTemplate>

                                <div class="row">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">

                                                <div class="col-xs-12">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtDescricaoAtendimento" runat="server" class="form-control" placeholder="Descreva aqui todos os procedimentos realizados com o animal" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <label for="usr">Consulta:</label>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">R$</div>
                                                        <asp:TextBox ID="txtConsultaValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <label for="usr">Cirurgia:</label>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">R$</div>
                                                        <asp:TextBox ID="txtCirurgiaValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <label for="usr">Soroterapia:</label>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">R$</div>
                                                        <asp:TextBox ID="txtSoroterapiaValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <label for="usr">Tartarectomia:</label>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">R$</div>
                                                        <asp:TextBox ID="txtTartarectomiaValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <label for="usr">Medicamentos:</label>
                                                    <div class="input-group">
                                                        <div class="input-group-addon">R$</div>
                                                        <asp:TextBox ID="txtMedicamentosValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="col-lg-2">
                                                    <div class="input-group">
                                                        <br>
                                                        </br>
                                                <button type="button" class="btn btn-primary" onclick="javascript:CalcularTotal()">Calcular Total</button>
                                                        <asp:Button ID="btnEditarConsulta" runat="server" Text="Alterar Consulta" class="btn btn-primary" Visible="false" OnClick="btnEditarConsulta_Click" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">

                                                    <div class="col-lg-2">
                                                        <label for="usr">Exame Laboratório:</label>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">R$</div>
                                                            <asp:TextBox ID="txtExameValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-8">
                                                        <asp:TextBox ID="txtExameDescricao" runat="server" class="form-control" placeholder="Descrição exame laboratório"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">

                                                    <div class="col-lg-2">
                                                        <label for="usr">Vendas:</label>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">R$</div>
                                                            <asp:TextBox ID="txtVendaValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-8">
                                                        <asp:TextBox ID="txtVendaDescricao" runat="server" class="form-control" placeholder="Descrição das vendas"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="form-group">

                                                    <div class="col-lg-2">
                                                        <label for="usr">Outros:</label>
                                                    </div>

                                                    <div class="col-lg-2">
                                                        <div class="input-group">
                                                            <div class="input-group-addon">R$</div>
                                                            <asp:TextBox ID="txtOutrosValor" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                                        </div>
                                                    </div>

                                                    <div class="col-lg-8">
                                                        <asp:TextBox ID="txtOutrosDescricao" runat="server" class="form-control" placeholder="Descrição de outros"></asp:TextBox>
                                                    </div>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>

        <!-- Histórico de atendimento -->
        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Histórico de atendimentos</b></div>
                    <div class="panel-body">

                        <asp:UpdatePanel ID="upGridConsulta" runat="server">
                            <ContentTemplate>

                                <asp:GridView ID="GridConsulta" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
                                    OnRowCommand="GridConsulta_RowCommand" DataKeyNames="cd_consulta">
                                    <Columns>
                                        <asp:BoundField DataField="cd_consulta" HeaderText="#" />
                                        <asp:BoundField DataField="dt_consulta" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderStyle-Width="110">
                                            <HeaderStyle Width="110px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="nm_funcionario" HeaderText="Veterinária" HeaderStyle-Width="200">
                                            <HeaderStyle Width="200px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ds_consulta" HeaderText="Descrição do atendimento" />
                                        <asp:CommandField ButtonType="Image" EditImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowEditButton="True" HeaderStyle-Width="30" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/visualizar.png" ShowSelectButton="True" HeaderStyle-Width="30" />
                                    </Columns>
                                </asp:GridView>

                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>

                    </div>
                </div>
            </div>
        </div>



        <!-- Modal de pagamento -->
        <div id="pagamento" class="modal fade" tabindex="-1" role="dialog" data-backdrop="static" aria-labelledby="myLargeModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="gridSystemModalLabel">Formas de pagamento <b>- R$ 
                            <asp:Label ID="lblTotal" Text="0" runat="server"></asp:Label>
                            <asp:HiddenField ID="HiddenTotal" runat="server" />
                        </b></h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upPagamento" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <asp:RadioButtonList ID="tipoConsulta" runat="server" RepeatDirection="Horizontal" Width="570">
                                                <asp:ListItem Selected="True">Consulta Normal</asp:ListItem>
                                                <asp:ListItem>Gratuidade</asp:ListItem>
                                                <asp:ListItem>Cliente em D&#233;bito</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>

                                </div>

                                </div>

                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnCadastrarConsulta" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>

                        <div class="modal-footer">
                            <span id="mensagemErro" style="color: #FF0000; font-size: medium; float: left; padding-top: 5px;"></span>
                            <button type="button" class="btn btn-danger" data-dismiss="modal">Fechar</button>
                            <asp:Button ID="btnCadastrarConsulta" runat="server" Text="Incluir Consulta" class="btn btn-success" OnClientClick="return verificaNulo()" OnClick="btnCadastrarConsulta_Click" />
                        </div>

                    </div>
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

                                    <div class="col-xs-4">
                                        <label for="usr">Data da Consulta</label>
                                        <h4><b>
                                            <asp:Label ID="lblDt_Consulta" runat="server"></asp:Label></b></h4>
                                    </div>

                                    <div class="col-xs-4">
                                        <label for="usr">Veterinária</label>
                                        <h4><b>
                                            <asp:Label ID="lblveterinaria" runat="server"></asp:Label></b></h4>
                                    </div>

                                    <div class="col-xs-4 text-center">
                                        <label for="usr">Tipo</label>
                                        <h4><b>
                                            <asp:Label ID="lblStatusConsulta" runat="server"></asp:Label></b></h4>
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


        <script type="text/javascript">

            function CalcularTotal() {

                var valor1 = document.getElementById("Corpo_txtConsultaValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtConsultaValor").value);
                var valor2 = document.getElementById("Corpo_txtCirurgiaValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtCirurgiaValor").value);
                var valor3 = document.getElementById("Corpo_txtSoroterapiaValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtSoroterapiaValor").value);
                var valor4 = document.getElementById("Corpo_txtTartarectomiaValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtTartarectomiaValor").value);
                var valor5 = document.getElementById("Corpo_txtMedicamentosValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtMedicamentosValor").value);
                var valor6 = document.getElementById("Corpo_txtExameValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtExameValor").value);
                var valor7 = document.getElementById("Corpo_txtVendaValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtVendaValor").value);
                var valor8 = document.getElementById("Corpo_txtOutrosValor").value == "" ? 0 : parseFloat(document.getElementById("Corpo_txtOutrosValor").value);
                var valor9 = document.getElementById("Corpo_hiddenVacinas").value == "" ? 0 : parseFloat(document.getElementById("Corpo_hiddenVacinas").value);

                var total = parseFloat(valor1 + valor2 + valor3 + valor4 + valor5 + valor6 + valor7 + valor8 + valor9);
                document.getElementById("Corpo_lblTotal").innerHTML = total;
                document.getElementById("Corpo_HiddenTotal").value = total;

                document.getElementById("mensagemErro").innerHTML = "";

                $("#pagamento").modal("show");
            }

            function verificaNulo() {
                var ds_atendimento = document.getElementById("Corpo_txtDescricaoAtendimento").value;

                if (ds_atendimento == "") {
                    document.getElementById("mensagemErro").innerHTML = "Preencha a descrição do atendimento!";
                    return false;
                } else if (total == 0) {
                    document.getElementById("mensagemErro").innerHTML = "Não há valor para o procedimento R$0,00!";
                    return false;
                } else {
                    return true;
                }


            }
        </script>

    </form>



</asp:Content>

