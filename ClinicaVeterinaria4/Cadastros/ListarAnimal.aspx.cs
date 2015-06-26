using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarAnimal : Model.Shared.PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!this.IsPostBack)
            {
                listarGrid("", "");
            }
        }

        private void listarGrid(string nm_animal, string nm_responsavel)
        {
            var dados = from a in contexto.animal
                        where a.nm_animal.Contains(nm_animal) & a.responsavel.nm_responsavel.Contains(nm_responsavel)
                        select new
                        {
                            cd_animal = a.cd_animal,
                            cd_responsavel = a.cd_responsavel,
                            nm_animal = a.nm_animal,
                            nm_raca = a.raca.nm_raca,
                            nm_especie = a.especie.nm_especie,
                            nm_responsavel = a.responsavel.nm_responsavel,
                            celular = a.responsavel.celular
                        };
            this.gridAnimal.DataSource = dados.ToList();
            this.gridAnimal.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string animal = txtAnimal.Text;
            string responsavel = txtResponsavel.Text;

            listarGrid(animal, responsavel);
        }

        protected void gridAnimal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = int.Parse((string)e.CommandArgument);
            string cd_animal = gridAnimal.DataKeys[index]["cd_animal"].ToString();
            HttpContext.Current.Items["cd_animal"] = cd_animal;

            string cd_responsavel = gridAnimal.DataKeys[index]["cd_responsavel"].ToString();
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

            if (e.CommandName == "Edit")
            {
                //Enviando ID para edição
                HttpContext.Current.Session["novo"] = "NovoAnimal";
                Server.Transfer("cadastroAnimal_Novo.aspx");
            }

            if (e.CommandName == "New")
            {
                //Enviando ID para histórico de vacinas
                Server.Transfer("CadastrarHistVacina.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CadastroAnimal_Responsavel.aspx");
        }
    }
}