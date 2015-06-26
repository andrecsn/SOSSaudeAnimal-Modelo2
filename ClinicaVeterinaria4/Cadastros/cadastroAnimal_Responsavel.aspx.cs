using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ClinicaVeterinaria
{
    public partial class cadastroAnimal : Business.Animal_Business
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            autenticarUsuario();

            if (!IsPostBack)
            {
                listarRaca();
                listarEspecie();
            }

            var cd_animal = HttpContext.Current.Items["cd_animal"];
        }

        protected void listarRaca()
        {
            //Adicionando a raça na combo
            var raca = from c in contexto.raca select new { c.cd_raca, c.nm_raca };
            cboRaca.DataSource = raca.ToList();
            cboRaca.DataValueField = "cd_raca";
            cboRaca.DataTextField = "nm_raca";
            cboRaca.DataBind();
            cboRaca.Items.Insert(0, "--Select--");
        }

        protected void listarEspecie()
        {
            //Adicionando a especie na combo
            var especie = from c in contexto.especie select new { c.cod_especie, c.nm_especie };
            cboEspecie.DataSource = especie.ToList();
            cboEspecie.DataValueField = "cod_especie";
            cboEspecie.DataTextField = "nm_especie";
            cboEspecie.DataBind();
            cboEspecie.Items.Insert(0, "--Select--");
        }

        private int incluirResponsavel()
        {
            int codResponsavel = 0;
            try
            {
                string nome = txtNomeResp.Text;
                string cpf = txtCPFResp.Text;
                string telefone = txtTelefoneResp.Text;
                string celular = txtCelularResp.Text;
                string email = txtEmailResp.Text;
                string endereco = txtEnderecoResp.Text;
                string bairro = txtBairroResp.Text;
                string cidade = txtCidadeResp.Text;
                string estado = cboEstadoResp.Text;

                codResponsavel = cadastrarResponsavel(nome, cpf, telefone, celular, email, endereco, bairro, cidade, estado);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
            return codResponsavel;
        }

        private void incluirAnimal(int responsavel)
        {
            try
            {
                string nm_animal = txtNome.Text;
                string cor = txtCor.Text;
                string peso = txtPeso.Text;
                DateTime dt_nascimento = Convert.ToDateTime(txtNascimento.Text);
                string sexo = cboSexo.SelectedValue;
                int raca = Convert.ToInt32(cboRaca.SelectedValue.ToString());
                int especie = Convert.ToInt32(cboEspecie.SelectedValue.ToString());
                string inf_animal = txtInformacoes.Text;
                string foto = arqFoto.FileName.ToString();

                cadastrarAnimal(nm_animal, cor, peso, dt_nascimento, sexo, responsavel, raca, especie, inf_animal, foto);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        protected void btnCadastrar_Click(object sender, EventArgs e)
        {
            var cdResponsavel = incluirResponsavel();
            incluirAnimal(cdResponsavel);
        }

        protected void btnVoltar_click(object sender, EventArgs e)
        {
            Server.Transfer("listarAnimal.aspx");
        }

    }
}