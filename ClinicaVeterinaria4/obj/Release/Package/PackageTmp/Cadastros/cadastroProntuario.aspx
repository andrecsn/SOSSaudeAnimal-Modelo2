<%@ Page Title="" Language="C#" MasterPageFile="~/Cadastros/Site1.Master" AutoEventWireup="true" CodeBehind="cadastroProntuario.aspx.cs" Inherits="ClinicaVeterinaria.cadastroProntuario" %>


<asp:Content ID="Content1" ContentPlaceHolderID="Corpo" runat="server">

    <form id="form1" runat="server" class="jumbotron">

        <h4>Dados do Animal</h4>

        </br>

            <div class="row">

                <asp:Label ID="lblCodigo" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

                <div class="col-xs-3">
                    <label for="usr">Nome:</label>
                    <asp:Label ID="lblNome" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-3">
                    <label for="usr">Pelagem:</label>
                    <asp:Label ID="lblCor" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Peso:</label>
                    <asp:Label ID="lblPeso" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-3">
                    <label for="usr">Data de Nascimento:</label>
                    <asp:Label ID="lblNascimento" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-3">
                    <label for="usr">Sexo:</label>
                    <asp:Label ID="lblSexo" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-3">
                    <label for="usr">Raça:</label>
                    <asp:Label ID="lblraca" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-4">
                    <label for="usr">Especie:</label>
                    <asp:Label ID="lblEspecie" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-12">
                    <label for="usr">Informações:</label>
                    <asp:Label ID="lblInformacoes" runat="server" Text="Label"></asp:Label>
                </div>

                <div class="col-xs-7">
                    <label for="usr">Foto:</label>
                    <asp:Label ID="lblFoto" runat="server" Text="Label" Visible="False"></asp:Label>
                </div>
            </div>

        <div class="separador"></div>
        <p></p>


        <h4>Dados do Responsável do animal.</h4>

        </br>

    <div class="row">

        <asp:Label ID="lblCodigoResp" runat="server" Text="" Visible="False" Enabled="False"></asp:Label>

        <div class="col-xs-4">
            <label for="usr">Nome:</label>
            <asp:Label ID="lblNomeResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">CPF:</label>
            <asp:Label ID="lblCPFResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Email:</label>
            <asp:Label ID="lblEmailResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Telefone:</label>
            <asp:Label ID="lblTelefoneResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Celular:</label>
            <asp:Label ID="lblCelularResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Endereço:</label>
            <asp:Label ID="lblEnderecoResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Bairro:</label>
            <asp:Label ID="lblBairroResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Cidade:</label>
            <asp:Label ID="lblCidadeResp" runat="server"></asp:Label>
        </div>

        <div class="col-xs-4">
            <label for="usr">Estado:</label>
            <asp:Label ID="lblEstadoResp" runat="server"></asp:Label>
        </div>

    </div>

        <div class="separador"></div>

        <h4>Aplicação e Histórico de Vacinas</h4>
        </br>

         <div class="col-xs-4">
             <label for="usr">Vacina: </label>
             <asp:DropDownList ID="cboVacina" runat="server" class="form-control">
             </asp:DropDownList>
         </div>

        <div class="col-xs-3">
            <label for="usr">Data de Aplicação: </label>
            <asp:TextBox ID="txtDt_aplicacao" runat="server" class="form-control" disabled></asp:TextBox>
        </div>

        <div class="col-xs-3">
            <label for="usr">Revacinação:</label>
            <asp:TextBox ID="txtDt_vencimento" runat="server" class="form-control" placeholder="00/00/0000" required TextMode="Date"></asp:TextBox>
        </div>

        <div class="col-xs-2">
            </br>
            <asp:Button ID="btnCadastrarVacina" runat="server" Text="Incluir Vacina" class="btn btn-primary" OnClick="btnCadastrarVacina_Click" />
        </div>

        <p>&nbsp</p>

        <asp:GridView ID="gridVacina" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None"
            OnRowCommand="gridVacina_RowCommand" DataKeyNames="cd_animal">
            <Columns>
                <asp:BoundField DataField="cd_hist_vacina" HeaderText="#" />
                <asp:BoundField DataField="vacina.nm_vacina" HeaderText="Vacina" />
                <asp:BoundField DataField="dt_hist_vacina" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Data de Aplicação" />
                <asp:BoundField DataField="dt_vencimento" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderText="Revacinar" />
                <asp:BoundField DataField="funcionario.nm_funcionario" HeaderText="Veterinário" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

        <div class="separador"></div>
        <p></p>

        <h4>Descrição do Atendimento</h4>
        </br>

            <div class="col-xs-4">
                <div class="input-group">
                    <div class="input-group-addon">R$</div>
                    <asp:TextBox ID="txtValorAtendimento" runat="server" class="form-control" placeholder="Valor do atendimento" required></asp:TextBox>
                </div>
            </div>

        <div class="col-xs-2">
            <asp:Button ID="btnCadastrarConsulta" runat="server" Text="Cadastrar" class="btn btn-primary" OnClick="btnCadastrarConsulta_Click1" />
        </div>

        <p>&nbsp</p>

        <div class="col-xs-13">
            <asp:TextBox ID="txtDescricaoAtendimento" runat="server" class="form-control" placeholder="Descreva aqui todos os procedimentos realizados com o animal" required TextMode="MultiLine" Rows="4"></asp:TextBox>
        </div>

        </br>
        

        <asp:GridView ID="GridConsulta" runat="server" AutoGenerateColumns="False" CssClass="table table-hover" GridLines="None">
            <Columns>
                <asp:BoundField DataField="cd_consulta" HeaderText="#" />
                <asp:BoundField DataField="dt_consulta" HeaderText="Data" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false" HeaderStyle-Width="110" />
                <asp:BoundField DataField="funcionario.nm_funcionario" HeaderText="Veterinária" HeaderStyle-Width="200" />
                <asp:BoundField DataField="ds_consulta" HeaderText="Descrição do atendimento" />
                <asp:CommandField ButtonType="Image" SelectImageUrl="~/App_Themes/Bootstrap/images/select.png" ShowSelectButton="True" />
                <asp:CommandField ButtonType="Image" DeleteImageUrl="~/App_Themes/Bootstrap/images/delete.png" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </form>
</asp:Content>

