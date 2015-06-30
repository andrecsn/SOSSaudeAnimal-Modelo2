<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="teste2.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.teste2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <!-- Testeee -->
        <div id="modal" class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-md">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="gridSystemModalLabel2">Informações da Consulta</h4>
                    </div>

                    <div class="modal-body">
                        <div class="row">

                            <div class="col-xs-4">
                                <label for="usr">Dinheiro:</label>
                                <div class="input-group">
                                    <div class="input-group-addon">R$</div>
                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)" autofocus></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-xs-4">
                                <label for="usr">C. Crédito:</label>
                                <div class="input-group">
                                    <div class="input-group-addon">R$</div>
                                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-xs-4">
                                <label for="usr">C. Débito:</label>
                                <div class="input-group">
                                    <div class="input-group-addon">R$</div>
                                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" placeholder="0,00" onKeyUp="formataValor(this)"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                        <asp:Button ID="Button1" runat="server" Text="Incluir Consulta" class="btn btn-success" />
                    </div>

                    <button type="button" class="btn btn-primary" onclick="javascript:fechar()">Fechar</button>

                </div>
            </div>
        </div>

        <button type="button" class="btn btn-primary" onclick="javascript:modal()">Launch modal</button>
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#modal" onclick="javascript:fechar()">Fechar</button>


        <button type="button" class="btn btn-default" id="left" title="Tooltip on top">Tooltip on top</button>

    </form>

    <script type="text/javascript">

        
            $("#left").tooltip({
                placement: 'left'
            });
            $("#top").tooltip({
                placement: 'top'
            });
            $("#bottom").tooltip({
                placement: 'bottom'
            });

            $("#right").tooltip({
                placement: 'right'
            });



        function modal() {
            $("#modal").modal("show");
        }
        function fechar() {
            $("#modal").modal("hide");
        }


        

    </script>

</asp:Content>
