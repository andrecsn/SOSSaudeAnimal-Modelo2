<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.teste" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

        <form id="form1" runat="server" class="jumbotron">

        <div class="container">
            <div class="row">
                <div class='col-sm-6'>
                    <div class="form-group">
                        <div class='input-group date' id='datetimepicker1'>
                            <asp:TextBox ID="txtDt_aplicacao" runat="server" class="form-control data" required></asp:TextBox>
                            <span class="input-group-addon">
                                <span class="glyphicon glyphicon-calendar"></span>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>

    </form>


    <!-- Load jQuery and bootstrap datepicker scripts -->
    <script src="../App_Themes/Bootstrap/js/jquery-1.11.3.min.js"></script>
    <script src="../App_Themes/Bootstrap/js/bootstrap-datepicker.js"></script>

     <script type="text/javascript">
         // When the document is ready
         $(document).ready(function () {

             $('.data').datepicker({
                 format: "dd/mm/yyyy"
             });

         });
        </script>

</asp:Content>
