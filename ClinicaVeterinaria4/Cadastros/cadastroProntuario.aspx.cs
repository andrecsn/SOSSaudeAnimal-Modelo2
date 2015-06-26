using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroProntuario : Business.Prontuario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            //setando txt com data atual do sistema
            txtDt_aplicacao.Text = DateTime.Now.Date.ToShortDateString();

            if (!IsPostBack)
            {
                //listando vacinas no ComboBox
                listarVacina();

                //pegando ID
                int cd_responsavel = Convert.ToInt32(HttpContext.Current.Items["cd_responsavel"]);
                int cd_animal = Convert.ToInt32(HttpContext.Current.Items["cd_animal"]);
                var alterarConsulta = HttpContext.Current.Items["alterarConsulta"];

                //Listando histórico de vacinas do animal e consultas no Grid
                listarHistVacina(cd_animal);
                listarConsulta(cd_animal);

                //Exibindo informações de animal e responsavel na tela
                exibirResponsavel(Convert.ToInt32(cd_responsavel));
                exibirAnimal(Convert.ToInt32(cd_animal));

                //Ezibindo alteração de consulta
                if (alterarConsulta == "Alterar")
                {
                    int cd_consulta = Convert.ToInt32(HttpContext.Current.Session["cd_consulta"]);
                    exibirAlterarConsulta(cd_consulta);
                }
            }
        }

        protected void exibirAlterarConsulta(int consulta)
        {
            Models.consulta Editarconsulta = contexto.consulta.First(x => x.cd_consulta == consulta);

            txtDescricaoAtendimento.Text = Editarconsulta.ds_consulta;
            //txtValorAtendimento.Text = Editarconsulta.varlor_total.ToString();

            MultviewHistoricoVacinas.ActiveViewIndex -= 1;

            btnEditarConsulta.Visible = true;
            btnCadastrarConsulta.Visible = false;
        }

        protected void listarHistVacina(int cd_animal)
        {
            var dados = from a in contexto.historico_vacina
                        where a.cd_animal == cd_animal
                        select new
                        {
                            cd_animal = a.cd_animal,
                            cd_hist_vacina = a.cd_hist_vacina,
                            nm_vacina = a.vacina.nm_vacina,
                            dt_hist_vacina = a.dt_hist_vacina,
                            dt_vencimento = a.dt_vencimento,
                            nm_funcionario = a.funcionario.nm_funcionario
                        };
            this.gridVacina.DataSource = dados.ToList();
            this.gridVacina.DataBind();
        }

        protected void listarConsulta(int cd_animal)
        {
            var dados = from a in contexto.consulta
                        where a.cd_animal == cd_animal
                        select new
                        {
                            cd_consulta = a.cd_consulta,
                            dt_consulta = a.dt_consulta,
                            nm_funcionario = a.funcionario.nm_funcionario,
                            ds_consulta = a.ds_consulta
                        };
            this.GridConsulta.DataSource = dados.ToList();
            this.GridConsulta.DataBind();
        }

        protected void listarVacina()
        {
            //Adiconando o resposanvél na na combo
            var vacina = from c in contexto.vacina select new { c.cd_vacina, c.nm_vacina };
            cboVacina.DataSource = vacina.ToList();
            cboVacina.DataValueField = "cd_vacina";
            cboVacina.DataTextField = "nm_vacina";
            cboVacina.DataBind();
            cboVacina.Items.Insert(0, "--Select--");
        }

        private void exibirAnimal(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigo.Text = codigo.ToString();
                Models.animal animal = contexto.animal.First(x => x.cd_animal == codigo);

                lblNome.Text = animal.nm_animal;
                lblCor.Text = animal.cor;
                lblPeso.Text = animal.peso;
                lblNascimento.Text = Convert.ToDateTime(animal.dt_nascimento).ToShortDateString();
                lblSexo.Text = animal.sexo;
                lblEspecie.Text = animal.especie.nm_especie;
                lblraca.Text = animal.raca.nm_raca;
                lblInformacoes.Text = animal.inf_animal;
            }
        }

        private void exibirResponsavel(int codigo)
        {
            if (codigo != 0)
            {
                lblCodigoResp.Text = codigo.ToString();
                Models.responsavel responsavel = contexto.responsavel.First(x => x.cd_responsavel == codigo);

                lblNomeResp.Text = responsavel.nm_responsavel;
                lblCPFResp.Text = responsavel.CPF;
                lblEmailResp.Text = responsavel.email;
                lblTelefoneResp.Text = responsavel.telefone;
                lblCelularResp.Text = responsavel.celular;
                lblEnderecoResp.Text = responsavel.endereco;
                lblBairroResp.Text = responsavel.bairro;
                lblCidadeResp.Text = responsavel.cidade;
                lblEstadoResp.Text = responsavel.estado;
            }
        }

        protected void gridVacina_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridVacina.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Items["cd_animal"] = cd_animal;

            string cd_responsavel = gridVacina.DataKeys[index]["cd_responsavel"].ToString();
            HttpContext.Current.Items["cd_responsavel"] = cd_responsavel;

            if (e.CommandName == "Select")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["alterar"] = "Alterar";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "Delete")
            {
                //Enviando ID para exclusão
                HttpContext.Current.Session["excluir"] = "Excluir";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }
        }

        protected void btnCadastrarVacina_Click(object sender, EventArgs e)
        {
            try
            {
                HttpContext.Current.Session["cd_responsavel"] = lblCodigoResp.Text;
                int cd_animal = Convert.ToInt32(lblCodigo.Text);
                int cd_vacina = Convert.ToInt32(cboVacina.SelectedValue.ToString());
                int cd_funcionario = Convert.ToInt32(HttpContext.Current.Session["cd_usuario"]);
                DateTime dt_aplicacao = Convert.ToDateTime(txtDt_aplicacao.Text);
                DateTime dt_vencimento = Convert.ToDateTime(txtDt_vencimento.Text);

                cadastrarHistoricoVacina(cd_animal, cd_vacina, dt_aplicacao, dt_vencimento, cd_funcionario, "cadastroProntuario.aspx");
                listarHistVacina(cd_animal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void GridConsulta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            HttpContext.Current.Items["cd_animal"] = lblCodigo.Text;
            HttpContext.Current.Items["cd_responsavel"] = lblCodigoResp.Text;

            int index = int.Parse((string)e.CommandArgument);
            string cd_consulta = GridConsulta.DataKeys[index]["cd_consulta"].ToString();
            HttpContext.Current.Session["cd_consulta"] = cd_consulta;

            if (e.CommandName == "Select22")
            {
                //Enviando ID para edição
                HttpContext.Current.Items["alterarConsulta"] = "Alterar";
                Server.Transfer("CadastroProntuario.aspx");
            }

            if (e.CommandName == "Select")
            {
                ////aaaaaaa
                int cd_consulta2 = Convert.ToInt32(cd_consulta);
                Models.consulta detalheConsulta = contexto.consulta.First(x => x.cd_consulta == cd_consulta2);
                TextBox1.Text = detalheConsulta.pg_dinheiro.ToString();
                TextBox2.Text = detalheConsulta.pg_debito.ToString();
                TextBox3.Text = detalheConsulta.pg_credito.ToString();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("$('#detalheConsulta').modal('show');");
                sb.Append("</script>");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "EditModalScript", sb.ToString(), false);

            }
        }

        protected void btnCadastrarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                //Informações
                DateTime dt_consulta = DateTime.Now;
                string ds_consulta = txtDescricaoAtendimento.Text;
                string st_consulta = "Realizado";
                int cd_funcionario = Convert.ToInt32(HttpContext.Current.Session["cd_usuario"]);
                int cd_animal = Convert.ToInt32(lblCodigo.Text);

                //Valores
                double vacinasValor = 0;
                double consultaValor = txtConsultaValor.Text == "" ? 0 : Convert.ToDouble(txtConsultaValor.Text);
                double cirurgiaValor = txtCirurgiaValor.Text == "" ? 0 : Convert.ToDouble(txtCirurgiaValor.Text);
                double soroterapiaValor = txtSoroterapiaValor.Text == "" ? 0 : Convert.ToDouble(txtSoroterapiaValor.Text);
                double medicamentosValor = txtMedicamentosValor.Text == "" ? 0 : Convert.ToDouble(txtMedicamentosValor.Text);
                double tartarectomiaValor = txtTartarectomiaValor.Text == "" ? 0 : Convert.ToDouble(txtTartarectomiaValor.Text);
                double outrosValor = txtOutrosValor.Text == "" ? 0 : Convert.ToDouble(txtOutrosValor.Text);
                double exameValor = txtExameValor.Text == "" ? 0 : Convert.ToDouble(txtExameValor.Text);
                double vendasValor = txtVendaValor.Text == "" ? 0 : Convert.ToDouble(txtVendaValor.Text);
                double valor_total = HiddenTotal.Value == "" ? 0 : Convert.ToDouble(HiddenTotal.Value);

                //pagamentos
                double pg_dinheiro = txtDinheiro.Text == "" ? 0 : Convert.ToDouble(txtDinheiro.Text);
                double pg_credito = txtCredito.Text == "" ? 0 : Convert.ToDouble(txtCredito.Text);
                double pg_debito = txtDebito.Text == "" ? 0 : Convert.ToDouble(txtDebito.Text);

                //Descrições
                string ds_outros = txtOutrosDescricao.Text;
                string ds_exame = txtExameDescricao.Text;
                string ds_vendas = txtVendaDescricao.Text;

                //calculo de saldo devedor
                double saldo_devedor = (valor_total - (pg_dinheiro + pg_debito + pg_credito));

                cadastrarConsulta(dt_consulta, ds_consulta, st_consulta, cd_funcionario, cd_animal, consultaValor, cirurgiaValor, soroterapiaValor, medicamentosValor, tartarectomiaValor, outrosValor, ds_outros, exameValor, ds_exame, vendasValor, ds_vendas, valor_total, saldo_devedor, pg_dinheiro, pg_credito, pg_debito);
                listarConsulta(cd_animal);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnEditarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int cd_consulta = Convert.ToInt32(HttpContext.Current.Session["cd_consulta"]);
                string ds_consulta = txtDescricaoAtendimento.Text;
                double valor_total = 0;//Convert.ToDouble(txtValorAtendimento.Text);

                editarConsulta(cd_consulta, ds_consulta, valor_total);
                listarConsulta( Convert.ToInt32(lblCodigo.Text));

                //Limpando campos e setando botões
                //txtValorAtendimento.Text = "";
                txtDescricaoAtendimento.Text = "";

                MultviewHistoricoVacinas.ActiveViewIndex = 0;

                btnCadastrarConsulta.Visible = true;
                btnEditarConsulta.Visible = false;

                //txtValorAtendimento.Focus();
                Session.Remove("cd_consulta");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}