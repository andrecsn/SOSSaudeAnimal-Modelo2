using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class RelatorioFinanceiro : Business.Prontuario_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dt_inicio = Convert.ToDateTime(txtDt_inicio.Text);
            DateTime dt_fim = Convert.ToDateTime(txtDt_fim.Text);

            listarCabecalho(dt_inicio, dt_fim);
            gerarRelatorio(dt_inicio, dt_fim);

            pnlImpressao.Visible = true;

        }

        private void listarCabecalho(DateTime dt_inicio, DateTime dt_fim)
        {
            int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_funcionario"]);
            hiddenCodigo.Value = codigo.ToString();

            Models.funcionario veterinaria = contexto.funcionario.First(x => x.cd_funcionario == codigo);
            lblVeterinaria.Text = veterinaria.nm_funcionario;

            lblDt_inicio.Text = dt_inicio.ToShortDateString();
            lblDt_Fim.Text = dt_fim.ToShortDateString();
        }

        private void gerarRelatorio(DateTime Dt_inicio, DateTime Dt_fim)
        {
            tblRelatorio.Controls.Clear();

            int linhas = Convert.ToInt32(Dt_fim.Subtract(Dt_inicio).TotalDays);
            DateTime data = Dt_inicio;

            double dinheiro = 0;
            double debito = 0;
            double credito = 0;

            gerarTitulos();

            for (int i = 0; i <= linhas; i++)
            {
                TableRow novaLinha = new TableRow();
                tblRelatorio.Controls.Add(novaLinha);

                for (int j = 0; j < 4; j++)
                {
                    TableCell novaColuna = new TableCell();
                    Label lblNew = new Label();

                    if (j == 0)
                    {
                        lblNew.Text = data.ToShortDateString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 1)
                    {
                        lblNew.Text = string.Format("{0:C}", calculoDinheiro(data));
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = string.Format("{0:C}", calculoDebito(data));
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = string.Format("{0:C}", calculoCredito(data));
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }
                }

                //calculando total das celulas
                dinheiro = dinheiro + calculoDinheiro(data);
                debito = debito + calculoDebito(data);
                credito = credito + calculoCredito(data);

                data = data.AddDays(1);
            }

            double debitoDesc = (debito - (debito * 0.03));
            double creditoDesc = (credito - (credito * 0.05));

            for (int i = 0; i < 1; i++)
            {
                TableRow novaLinha = new TableRow();
                tblRelatorio.Controls.Add(novaLinha);

                for (int j = 0; j < 4; j++)
                {
                    TableCell novaColuna = new TableCell();
                    Label lblNew = new Label();

                    if (j == 0)
                    {
                        lblNew.Text = "<b>TOTAL SEM DESCONTO</b>";
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 1)
                    {
                        lblNew.Text = string.Format("{0:C}", dinheiro);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = string.Format("{0:C}", debito);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = string.Format("{0:C}", credito);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }
                }
            }



            for (int i = 0; i < 1; i++)
            {
                TableRow novaLinha = new TableRow();
                tblRelatorio.Controls.Add(novaLinha);

                for (int j = 0; j < 4; j++)
                {
                    TableCell novaColuna = new TableCell();
                    Label lblNew = new Label();

                    if (j == 0)
                    {
                        lblNew.Text = "<b>TOTAL COM DESCONTO</b>";
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 1)
                    {
                        lblNew.Text = string.Format("{0:C}", dinheiro);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = string.Format("{0:C}", debitoDesc);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = string.Format("{0:C}", creditoDesc);
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }
                }
            }

            lblRecebiveisSDesconto.Text = string.Format("{0:C}", (dinheiro + debito + credito));
            lblRecebiveisCDesconto.Text = string.Format("{0:C}", (dinheiro + debitoDesc + creditoDesc));
            lbl60.Text = string.Format("{0:C}", ((dinheiro + debitoDesc + creditoDesc) * 0.6));
            lbl40.Text = string.Format("{0:C}", ((dinheiro + debitoDesc + creditoDesc) * 0.4));

            double totalEntradas = ((dinheiro + debito + credito) * 0.6);
            double totalCartaoRecebido = (debito + credito);
            double totalReceber = (totalEntradas - totalCartaoRecebido);

            lblTotalEntradas.Text = string.Format("{0:C}", totalEntradas);
            lblCartaoRecebido.Text = string.Format("{0:C}", totalCartaoRecebido);
            lblTotalReceber.Text = string.Format("{0:C}", totalReceber);

        }

        public void gerarTitulos()
        {
            for (int i = 0; i < 1; i++)
            {
                TableRow linhaTitulo = new TableRow();
                tblRelatorio.Controls.Add(linhaTitulo);

                for (int j = 0; j < 4; j++)
                {
                    TableCell colunaTitulo = new TableCell();
                    Label lblNew = new Label();

                    if (j == 0)
                    {
                        lblNew.Text = "<b>Data</b>";
                        colunaTitulo.Controls.Add(lblNew);
                        linhaTitulo.Controls.Add(colunaTitulo);
                    }

                    if (j == 1)
                    {
                        lblNew.Text = "<b>Dinheiro(R$)</b>";
                        colunaTitulo.Controls.Add(lblNew);
                        linhaTitulo.Controls.Add(colunaTitulo);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = "<b>Cartão de Débito</b>";
                        colunaTitulo.Controls.Add(lblNew);
                        linhaTitulo.Controls.Add(colunaTitulo);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = "<b>Cartão de Crédito</b>";
                        colunaTitulo.Controls.Add(lblNew);
                        linhaTitulo.Controls.Add(colunaTitulo);
                    }
                }
            }
        }

        private double calculoDinheiro(DateTime data)
        {
            int funcionario = Convert.ToInt32(hiddenCodigo.Value);

            string data2 = data.ToShortDateString();

            var dados = from a in contexto.consulta
                        where a.cd_funcionario == funcionario
                        & EntityFunctions.TruncateTime(a.dt_consulta) == data
                        select new
                        {
                            dinheiro = a.pg_dinheiro
                        };

            return Convert.ToDouble(dados.Sum(soma => soma.dinheiro));
        }

        private double calculoDebito(DateTime data)
        {
            int funcionario = Convert.ToInt32(hiddenCodigo.Value);

            string data2 = data.ToShortDateString();

            var dados = from a in contexto.consulta
                        where a.cd_funcionario == funcionario
                        & EntityFunctions.TruncateTime(a.dt_consulta) == data
                        select new
                        {
                            dinheiro = a.pg_debito
                        };

            return Convert.ToDouble(dados.Sum(soma => soma.dinheiro));
        }

        private double calculoCredito(DateTime data)
        {
            int funcionario = Convert.ToInt32(hiddenCodigo.Value);

            string data2 = data.ToShortDateString();

            var dados = from a in contexto.consulta
                        where a.cd_funcionario == funcionario
                        & EntityFunctions.TruncateTime(a.dt_consulta) == data
                        select new
                        {
                            dinheiro = a.pg_credito
                        };

            return Convert.ToDouble(dados.Sum(soma => soma.dinheiro));
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Response.Redirect("ListarFinanceiro.aspx");
        }
    }
}