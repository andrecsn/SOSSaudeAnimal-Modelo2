<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="RelatorioFinanceiro.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.RelatorioFinanceiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">


        <asp:Panel ID="css" runat="server">
            <style>
                .table {
                    font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
                    font-size: 14px;
                    color: #333;
                }

                    .table td {
                        border: 1px solid #ddd !important;
                    }

                .text-center {
                    text-align: center;
                }
            </style>
        </asp:Panel>


        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Relatório Financeiro - Pró-Labore</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Digite o intervalo de datas a serem relacionadas no relatório</b></div>
                    <div class="panel-body">

                        <div class="row">

                            <div class='col-lg-3'>
                                <div class="form-group">
                                    <label>Data início: </label>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txtDt_inicio" runat="server" class="form-control data" required></asp:TextBox>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class='col-lg-3'>
                                <div class="form-group">
                                    <label>Data Fim: </label>
                                    <div class='input-group date'>
                                        <asp:TextBox ID="txtDt_fim" runat="server" class="form-control data" required></asp:TextBox>
                                        <span class="input-group-addon">
                                            <span class="glyphicon glyphicon-calendar"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    </br>
                                        <asp:Button ID="btnPesquisar" runat="server" Text="Pesquisar" class="btn btn-success" OnClick="btnPesquisar_Click" />
                                    <asp:LinkButton ID="btnVoltar" runat="server" class="btn btn-primary" OnClick="btnVoltar_click">voltar</asp:LinkButton>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>



        <div class="row">
            <div class="col-lg-12">
                <div class="panel panel-default">
                    <div class="panel-heading"><b>Visualização do relatório para impressão</b></div>
                    <div class="panel-body">

                        <div class="row">

                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

                            <asp:UpdatePanel ID="upRelatorio" runat="server">
                                <ContentTemplate>

                                    <div class="row">
                                        <div class="col-lg-12 text-center">
                                            <div class="form-group">
                                                <button type="button" class="btn btn-info btn-circle btn-lg" onclick="javascript: imprimir()">
                                                    <i class="fa fa-print"></i>
                                            </div>
                                        </div>

                                        <asp:Panel ID="pnlImpressao" runat="server" ScrollBars="None" Visible="false">
                                            <div class="row">
                                                <div class="col-lg-3">
                                                </div>
                                                <div class="col-lg-6">
                                                    <table style="width: 100%;" class="table table-striped table-bordered">
                                                        <tr>
                                                            <td class="text-center">
                                                                <b>Pró-Labore - De:
                                <asp:Label ID="lblDt_inicio" runat="server"></asp:Label>
                                                                    Até
                                <asp:Label ID="lblDt_Fim" runat="server"></asp:Label></b>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="text-center">
                                                                <b>Veterinária:
                                <asp:Label ID="lblVeterinaria" runat="server"></asp:Label></b>
                                                                <asp:HiddenField ID="hiddenCodigo" runat="server" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-3">
                                                </div>
                                                <div class="col-lg-6">

                                                    <asp:Table ID="tblRelatorio" Width="100%" CssClass="table table-striped table-bordered" runat="server" />

                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-lg-3">
                                                </div>
                                                <div class="col-lg-6">

                                                    <table style="width: 100%;" class="table table-striped table-bordered">
                                                        <tr class="text-center">
                                                            <td><b>RECEBÍVEIS S/DESCONTO</b></td>
                                                            <td><b>RECEBÍVEIS C/DESCONTO</b></td>
                                                            <td><b>60%</b></td>
                                                            <td><b>40%</b></td>
                                                        </tr>
                                                        <tr class="text-center">
                                                            <td>
                                                                <asp:Label ID="lblRecebiveisSDesconto" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lblRecebiveisCDesconto" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl60" runat="server"></asp:Label></td>
                                                            <td>
                                                                <asp:Label ID="lbl40" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>

                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-lg-3">
                                                </div>
                                                <div class="col-lg-6">

                                                    <table style="width: 100%;" class="table table-bordered">
                                                        <tr>
                                                            <td><b>TOTAL A RECEBER (Bruto)</b></td>
                                                            <td>
                                                                <asp:Label ID="lblTotalEntradas" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <b>TOTAL CARTÃO JÁ RECEBIDO</b></td>
                                                            <td>
                                                                <asp:Label ID="lblCartaoRecebido" runat="server"></asp:Label></td>
                                                        </tr>
                                                        <tr class="success">
                                                            <td>
                                                                <b>TOTAL A RECEBER (Líquido)</b></td>
                                                            <td>
                                                                <asp:Label ID="lblTotalReceber" runat="server"></asp:Label></td>
                                                        </tr>
                                                    </table>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnPesquisar" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>



    <script language="javascript" type="text/jscript">

        function imprimir() {
            var printContent = document.getElementById("<%=pnlImpressao.ClientID%>");
            var css = document.getElementById("<%=css.ClientID%>");
            var windowUrl = 'about:blank';
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(windowUrl, windowName, 'left=50000,top=50000,width=0,height=0');

            printWindow.document.write(css.innerHTML);
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }

    </script>


</asp:Content>
