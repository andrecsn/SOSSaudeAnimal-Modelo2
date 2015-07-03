﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria.Cadastros
{
    public partial class ListarProntuario : Model.Shared.PageBase
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
            this.gridProntuario.DataSource = dados.ToList();
            this.gridProntuario.DataBind();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            string animal = txtAnimal.Text;
            string responsavel = txtResponsavel.Text;

            listarGrid(animal, responsavel);
        }

        protected void gridProntuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse((string)e.CommandArgument);
                string cd_animal = gridProntuario.DataKeys[index]["cd_animal"].ToString();
                HttpContext.Current.Items["cd_animal"] = cd_animal;

                string cd_responsavel = gridProntuario.DataKeys[index]["cd_responsavel"].ToString();
                HttpContext.Current.Items["cd_responsavel"] = cd_responsavel;

                Server.Transfer("cadastroProntuario.aspx");
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            Server.Transfer("CadastroAnimal_Responsavel.aspx");
        }
    }
}