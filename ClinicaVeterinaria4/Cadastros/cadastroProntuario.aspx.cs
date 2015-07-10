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
            verificaPerfil(this.Page.ToString());

            //setando txt com data atual do sistema
            txtDt_aplicacao.Text = DateTime.Now.Date.ToShortDateString();

            if (!IsPostBack)
            {
                //listando vacinas no ComboBox
                listarVacina();

                //pegando ID
                int cd_responsavel = Convert.ToInt32(HttpContext.Current.Session["cd_responsavel"]);
                int cd_animal = Convert.ToInt32(HttpContext.Current.Session["cd_animal"]);
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
            var vacina = from c in contexto.vacina where c.st_vacina == "Ativo" select new { c.cd_vacina, c.nm_vacina };
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

                if (animal.foto != "")
                {
                    foto.ImageUrl = "~/App_Themes/Bootstrap/images/imagens_upload/" + animal.foto;
                }
                else
                {
                    foto.ImageUrl = "~/App_Themes/Bootstrap/images/sem-foto.jpg";
                }
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

                //Calculando total
                Models.vacina vacina = contexto.vacina.First(x => x.cd_vacina == cd_vacina);
                double valorVacina = Convert.ToDouble(hiddenVacinas.Value);
                double totalVacinas = (valorVacina + Convert.ToDouble(vacina.valor));
                lblTotalVacinas.Text = string.Format("{0:C}", totalVacinas);
                hiddenVacinas.Value = totalVacinas.ToString();

                //Cadastrando vacina
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

            if (e.CommandName == "Select")
            {
                detalhesModal(cd_consulta);
                modal("#detalheConsulta", "show");
            }
        }

        private void detalhesModal(string cd_consulta)
        {
            int cd_consulta2 = Convert.ToInt32(cd_consulta);
            Models.consulta detalheConsulta = contexto.consulta.First(x => x.cd_consulta == cd_consulta2);
            lblDt_Consulta.Text = detalheConsulta.dt_consulta.ToString();
            lblveterinaria.Text = detalheConsulta.funcionario.nm_funcionario.ToString();
            lblDsConsulta.Text = detalheConsulta.ds_consulta.ToString();

            int cd_usuario = Convert.ToInt32(HttpContext.Current.Session["cd_usuario"]);

            lblValorConsulta.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_consulta);
            lblValorCirurgia.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_cirurgia);
            lblValorSoroterapia.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_soroterapia);
            lblValortartarectomia.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_tartarectomia);
            lblValorMedicamentos.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_medicamentos);
            lblValorVacinas.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_vacinas);
            lblValorOutros.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_outros);
            lblDescricaoOutros.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : detalheConsulta.ds_outros.ToString();
            lblValorExame.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_exame);
            lblDescricaoExame.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : detalheConsulta.ds_exame.ToString();
            lblValorVendas.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_vendas);
            lblDescricaoVendas.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : detalheConsulta.ds_vendas.ToString();

            lblValorDinheiro.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.pg_dinheiro);
            lblValorDebito.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.pg_debito);
            lblValorCredito.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.pg_credito);
            lblTotalModal.Text = detalheConsulta.cd_funcionario != cd_usuario ? "---" : string.Format("{0:C}", detalheConsulta.valor_total);

            lblSaldoDevedor.Text = string.Format("{0:C}", detalheConsulta.saldo_devedor);
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
                double vacinasValor = Convert.ToDouble(hiddenVacinas.Value);
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

                cadastrarConsulta(dt_consulta, ds_consulta, st_consulta, cd_funcionario, cd_animal, consultaValor, cirurgiaValor, soroterapiaValor, medicamentosValor, vacinasValor, tartarectomiaValor, outrosValor, ds_outros, exameValor, ds_exame, vendasValor, ds_vendas, valor_total, saldo_devedor, pg_dinheiro, pg_credito, pg_debito);
                limpaCampos();
                listarConsulta(cd_animal);
                modal("#pagamento", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private void limpaCampos()
        {
            txtDescricaoAtendimento.Text = "";
            hiddenVacinas.Value = "0";
            lblTotalVacinas.Text = "0";
            txtConsultaValor.Text = "";
            txtCirurgiaValor.Text = "";
            txtSoroterapiaValor.Text = "";
            txtMedicamentosValor.Text = "";
            txtTartarectomiaValor.Text = "";
            txtOutrosValor.Text = "";
            txtExameValor.Text = "";
            txtVendaValor.Text = "";
            HiddenTotal.Value = "0";
            txtDinheiro.Text = "";
            txtCredito.Text = "";
            txtDebito.Text = "";
            txtOutrosDescricao.Text = "";
            txtExameDescricao.Text = "";
            txtVendaDescricao.Text = "";
        }

        protected void btnEditarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                int cd_consulta = Convert.ToInt32(HttpContext.Current.Session["cd_consulta"]);
                string ds_consulta = txtDescricaoAtendimento.Text;
                double valor_total = 0;//Convert.ToDouble(txtValorAtendimento.Text);

                editarConsulta(cd_consulta, ds_consulta, valor_total);
                listarConsulta(Convert.ToInt32(lblCodigo.Text));

                //Limpando campos e setando botões
                //txtValorAtendimento.Text = "";
                txtDescricaoAtendimento.Text = "";

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