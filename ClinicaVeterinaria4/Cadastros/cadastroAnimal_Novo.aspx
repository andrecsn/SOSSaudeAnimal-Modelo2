<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="CadastroAnimal_Novo.aspx.cs" Inherits="ClinicaVeterinaria.cadastroAnimal_Novo" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                Dados do Animal e Responsável
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Dados básicos de cadastro do Responsável</b></div>
                    <div class="panel-body">

                        <div class="col-lg-4">

                            <asp:Label ID="lblCodigoResp" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                            <div class="form-group">
                                <label for="usr">Nome:</label>
                                <asp:TextBox ID="txtNomeResp" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                                <asp:Label ID="lblNomeResp" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">CPF:</label>
                                <asp:TextBox ID="txtCPFResp" runat="server" class="form-control" placeholder="000.000.000-00"></asp:TextBox>
                                <asp:Label ID="lblCPFResp" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Telefone:</label>
                                <asp:TextBox ID="txtTelefoneResp" runat="server" class="form-control" placeholder="(xx) xxxx-xxxx" required></asp:TextBox>
                                <asp:Label ID="lblTelefoneResp" runat="server" Visible="false"></asp:Label>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Celular:</label>
                                <asp:TextBox ID="txtCelularResp" runat="server" class="form-control" placeholder="(xx) xxxxx-xxxx"></asp:TextBox>
                                <asp:Label ID="lblCelularResp" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Email:</label>
                                <asp:TextBox ID="txtEmailResp" runat="server" class="form-control" placeholder="nome@seuemail.com"></asp:TextBox>
                                <asp:Label ID="lblEmailResp" runat="server" Text="Label" Visible="False"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Endereço:</label>
                                <asp:TextBox ID="txtEnderecoResp" runat="server" class="form-control" placeholder="Endereço completos"></asp:TextBox>
                                <asp:Label ID="lblEnderecoResp" runat="server" Visible="false"></asp:Label>
                            </div>

                        </div>

                        <div class="col-lg-4">

                            <div class="form-group">
                                <label for="usr">Bairro:</label>
                                <asp:TextBox ID="txtBairroResp" runat="server" class="form-control"></asp:TextBox>
                                <asp:Label ID="lblBairroResp" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Cidade:</label>
                                <asp:TextBox ID="txtCidadeResp" runat="server" class="form-control"></asp:TextBox>
                                <asp:Label ID="lblCidadeResp" runat="server" Visible="false"></asp:Label>
                            </div>

                            <div class="form-group">
                                <label for="usr">Estado:</label>
                                <asp:DropDownList ID="cboEstadoResp" runat="server" class="form-control">
                                    <asp:ListItem Value="RJ">Rio de janeiro</asp:ListItem>
                                    <asp:ListItem Value="SP">São paulo</asp:ListItem>
                                </asp:DropDownList>
                                <asp:Label ID="lblEstadoResp" runat="server" Visible="false"></asp:Label>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


        <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

        <asp:UpdatePanel ID="upGrid" runat="server">
            <ContentTemplate>

                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading"><b>Outros animais desse responsável</b></div>
                            <div class="panel-body">

                                <asp:GridView ID="gridAnimal" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" GridLines="None"
                                    OnRowCommand="gridAnimal_RowCommand" DataKeyNames="cd_animal,cd_responsavel">
                                    <Columns>
                                        <asp:BoundField DataField="cd_animal" HeaderText="#" />
                                        <asp:BoundField DataField="nm_animal" HeaderText="Nome" />
                                        <asp:BoundField DataField="nm_raca" HeaderText="Raça" />
                                        <asp:BoundField DataField="nm_especie" HeaderText="Espécie" />
                                        <asp:BoundField DataField="inf_animal" HeaderText="informações" />
                                        <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="30">
                                            <HeaderStyle Width="30px" />
                                        </asp:CommandField>
                                        <asp:CommandField ButtonType="Image" HeaderStyle-Width="30" NewImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowInsertButton="True" />
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <b>
                                    <asp:Label ID="lblTitulo" runat="server" Text="Dados do novo animal"></asp:Label></b>
                            </div>
                            <div class="panel-body">
                                <div class="col-lg-8">

                                    <div class="row">
                                        <div class="col-lg-6">

                                            <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                                            <div class="form-group">
                                                <label for="usr">Nome:</label>
                                                <asp:TextBox ID="txtNome" runat="server" Columns="50" class="form-control" placeholder="Nome completo" required autofocus></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <label for="usr">Especie:</label>
                                                <asp:DropDownList ID="cboEspecie" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-lg-7">

                                                <div class="row">
                                                    <label for="usr">Sexo:</label>
                                                    <asp:DropDownList ID="cboSexo" runat="server" class="form-control">
                                                        <asp:ListItem Value="Macho">Macho</asp:ListItem>
                                                        <asp:ListItem Value="Fêmea">Fêmea</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-5">
                                                <label for="usr">Peso:</label>
                                                <asp:TextBox ID="txtPeso" runat="server" class="form-control" placeholder="Ex.: 10gr" required></asp:TextBox>
                                            </div>

                                        </div>

                                        <div class="col-lg-6">

                                            <div class="form-group">
                                                <label for="usr">Pelagem:</label>
                                                <asp:TextBox ID="txtCor" runat="server" class="form-control" required></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <div class="form-group">
                                                    <label>Data de Nascimento: </label>
                                                    <div class='input-group date'>
                                                        <asp:TextBox ID="txtNascimento" runat="server" class="form-control data" placeholder="00/00/0000" required></asp:TextBox>
                                                        <span class="input-group-addon">
                                                            <span class="glyphicon glyphicon-calendar"></span>
                                                        </span>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="form-group">
                                                <label for="usr">Raça:</label>
                                                <asp:DropDownList ID="cboRaca" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>

                                        </div>

                                    </div>

                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="form-group">
                                                <label>Informações:</label>
                                                <asp:TextBox ID="txtInformacoes" runat="server" Rows="4" class="form-control" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-lg-4 text-center img-responsive">

                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/Bootstrap/images/sem-foto.jpg" Height="300" Width="300" CssClass="img-circle" />

                                    <div class="form-group">
                                        <asp:FileUpload ID="arqFoto" runat="server" />
                                        <asp:Label ID="lblFoto" runat="server" Text="Label" Visible="False"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>


                <div class="row">
                    <div class="col-lg-12">
                        <div class="well well-sm">

                            <asp:Button ID="btnCadastrar" runat="server" Text="Cadastrar" class="btn btn-success" OnClick="btnCadastrar_Click" />
                            <asp:Button ID="btnAlterar" runat="server" Text="Alterar" class="btn btn-success" OnClick="btnAlterar_Click" Visible="False" />
                            <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>

                        </div>
                    </div>
                </div>

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
                        <h4 class="modal-title" id="gridSystemModalLabel1">Excluir Animal</h4>
                    </div>

                    <div class="modal-body">

                        <asp:UpdatePanel ID="upExcluir" runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-xs-12">
                                        <div class="input-group">
                                            <h4>Deseja mesmo excluir o animal <b>
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

