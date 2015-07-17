<%@ Page Title="" Language="C#" MasterPageFile="~/Presentation/Site1.Master" AutoEventWireup="true" CodeBehind="ListarFinanceiro.aspx.cs" Inherits="ClinicaVeterinaria.Presentation.ListarFinanceiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">


    <form id="form1" runat="server">

        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">
                    <asp:Label ID="lblTitulo" runat="server" Text="Listar Financeiro - Pró-Labore"></asp:Label></h1>
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
                    </div>
                </div>
            </div>
        </div>


        <div class="row">
            <div class="col-lg-12">

                <asp:ScriptManager ID="ScriptManager2" runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="upGrid" runat="server">
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
                                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" HeaderStyle-Width="50" />
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

    </form>


</asp:Content>
