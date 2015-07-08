<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="RelatorioFinanceiro.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.RelatorioFinanceiro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server">

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
            <div class="col-lg-3">
            </div>
            <div class="col-lg-5">
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
            <div class="col-lg-5">

                <asp:Table ID="tblRelatorio" CssClass="table table-striped table-bordered" runat="server" />

            </div>
        </div>

        <div class="row">
            <div class="col-lg-3">
            </div>
            <div class="col-lg-5">

                <table style="width: 100%;" class="table table-striped table-bordered">
                    <tr class="text-center">
                        <td><b>RECEBÍVEIS</b></td>
                        <td><b>60%</b></td>
                        <td><b>40%</b></td>
                    </tr>
                    <tr class="text-center">
                        <td>
                            <asp:Label ID="lblRecebiveis" runat="server"></asp:Label></td>
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
            <div class="col-lg-5">

                <table style="width: 100%;" class="table table-bordered">
                    <tr>
                        <td><b>TOTAL DE ENTRADAS</b></td>
                        <td>
                            <asp:Label ID="Label4" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <b>TOTAL CARTÃO JÁ RECEBIDO</b></td>
                        <td>
                            <asp:Label ID="Label2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <b>TOTAL A RECEBER</b></td>
                        <td>
                            <asp:Label ID="Label5" runat="server"></asp:Label></td>
                    </tr>
                </table>

            </div>
        </div>

    </form>


</asp:Content>
