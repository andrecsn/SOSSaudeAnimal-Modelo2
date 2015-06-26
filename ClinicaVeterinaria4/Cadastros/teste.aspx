<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teste.aspx.cs" Inherits="ClinicaVeterinaria.Cadastros.teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    

</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>

            <button type="button" class="btn btn-primary" onclick="javascript:calc()">Calcular Total</button>
        </div>
    </form>

    <script type="text/javascript">
        function calc() {
            var valor1 = document.getElementById('TextBox1').value;
            var valor2 = document.getElementById('TextBox2').value;

            var total = parseFloat(valor1 + valor2);
            alert(total);
        }
    </script>

</body>
</html>
