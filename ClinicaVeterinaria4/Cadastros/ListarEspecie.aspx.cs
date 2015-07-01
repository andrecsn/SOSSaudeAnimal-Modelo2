using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarEspecie : Business.Especie_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                listarGrid();
            }
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            listarGrid();
        }

        protected void listarGrid()
        {
            string parametro = txtNome.Text;

            if (parametro == "")
            {
                this.gridEspecie.DataSource = contexto.especie.Select(x => x).ToList();
                this.gridEspecie.DataBind();
            }
            else
            {
                this.gridEspecie.DataSource = contexto.especie.Where(x => x.nm_especie.Contains(parametro)).ToList();
                this.gridEspecie.DataBind();
            }
        }

        protected void gridEspecie_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_especie = gridEspecie.DataKeys[index]["cod_especie"].ToString();
            HttpContext.Current.Items["cod_especie"] = cd_especie;

            if (e.CommandName == "Select")
            {
                detalheModal(cd_especie);
                modal("#modalAlterar", "show");
            }

            if (e.CommandName == "New")
            {
                detalheModal(cd_especie);
                modal("#modalExcluir", "show");
            }
        }

        protected void detalheModal(string cd_especie)
        {
            int cd_especie2 = Convert.ToInt32(cd_especie);
            Models.especie detalheEspecie = contexto.especie.First(x => x.cod_especie == cd_especie2);

            hiddenCodigo.Value = detalheEspecie.cod_especie.ToString();
            lblNomeModal.Text = detalheEspecie.nm_especie.ToString();
            txtNomeModal.Text = detalheEspecie.nm_especie.ToString();
            HttpContext.Current.Session["cd_especie"] = cd_especie2;
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("cadastroEspecie.aspx");
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_especie"]);
                string nm_especie = txtNomeModal.Text.ToString();

                editarEspecie(codigo, nm_especie, "Ativo");
                listarGrid();
                modal("#modalAlterar", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Convert.ToInt32(HttpContext.Current.Session["cd_especie"]);

                excluirEspecie(codigo);
                listarGrid();
                modal("#modalExcluir", "hide");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }
    }
}