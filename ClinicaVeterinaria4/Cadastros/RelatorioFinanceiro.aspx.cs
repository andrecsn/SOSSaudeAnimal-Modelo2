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
            if (!this.IsPostBack)
            {

            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            DateTime dt_inicio = Convert.ToDateTime(txtDt_inicio.Text);
            DateTime dt_fim = Convert.ToDateTime(txtDt_fim.Text);

            listarCabecalho(dt_inicio, dt_fim);
            gerarRelatorio(dt_inicio, dt_fim);

        }

        private void listarCabecalho(DateTime dt_inicio, DateTime dt_fim)
        {
            int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_funcionario"]);
            hiddenCodigo.Value = codigo.ToString();

            Models.funcionario veterinaria = contexto.funcionario.First(x => x.cd_funcionario == codigo);
            lblVeterinaria.Text = veterinaria.nm_funcionario;

            lblDt_inicio.Text = dt_inicio.ToShortDateString();
            lblDt_Fim.Text = dt_fim.ToShortDateString();

            //Session.Remove("cd_funcionario");
        }

        private void gerarRelatorio(DateTime Dt_inicio, DateTime Dt_fim)
        {
            tblRelatorio.Controls.Clear();

            int linhas = Convert.ToInt32(Dt_fim.Subtract(Dt_inicio).TotalDays);
            DateTime data = Dt_inicio;

            double dinheiro = 0;
            double debito = 0;
            double credito = 0;

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
                        lblNew.Text = calculoDinheiro(data).ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = calculoDebito(data).ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = calculoCredito(data).ToString();
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
                        lblNew.Text = dinheiro.ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = debito.ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = credito.ToString();
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
                        lblNew.Text = dinheiro.ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 2)
                    {
                        lblNew.Text = debito.ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }

                    if (j == 3)
                    {
                        lblNew.Text = credito.ToString();
                        novaColuna.Controls.Add(lblNew);
                        novaLinha.Controls.Add(novaColuna);
                    }
                }
            }

            lblRecebiveis.Text = string.Format("{0:C}", (dinheiro + debito + credito));
            lbl60.Text = string.Format("{0:C}", ((dinheiro + debito + credito) * 0.6));
            lbl40.Text = string.Format("{0:C}", ((dinheiro + debito + credito) * 0.4));

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
            Server.Transfer("ListarFinanceiro.aspx");
        }
    }
}