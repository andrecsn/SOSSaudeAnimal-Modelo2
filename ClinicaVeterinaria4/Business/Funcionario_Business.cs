using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClinicaVeterinaria.Business
{
    public class Funcionario_Business : Model.Shared.PageBase
    {
        protected void cadastrarFuncionario(string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cep, string cidade, string estado, string login, string senha, string tipo)
        {
            Models.funcionario funcionario = new Models.funcionario()
            {
                nm_funcionario = nome,
                cpf = cpf,
                telefone = telefone,
                celular = celular,
                email = email,
                endereco = endereco,
                bairro = bairro,
                cep = cep,
                cidade = cidade,
                estado = estado,
                login = login,
                senha = senha,
                tipo = tipo
            };
            contexto.funcionario.Add(funcionario);
            contexto.SaveChanges();
            Response.Redirect("listarFuncionario.aspx");
        }

        protected void editarFuncionario(int codigo, string nome, string cpf, string telefone, string celular, string email, string endereco, string bairro, string cep, string cidade, string estado, string login, string senha, string tipo)
        {
            Models.funcionario funcionario = contexto.funcionario.First(x => x.cd_funcionario == codigo);

            funcionario.nm_funcionario = nome;
            funcionario.cpf = cpf;
            funcionario.telefone = telefone;
            funcionario.celular = celular;
            funcionario.email = email;
            funcionario.endereco = endereco;
            funcionario.bairro = bairro;
            funcionario.cep = cep;
            funcionario.cidade = cidade;
            funcionario.estado = estado;
            funcionario.login = login;
            funcionario.senha = senha;
            funcionario.tipo = tipo;

            contexto.SaveChanges();
            Response.Redirect("listarFuncionario.aspx");
        }

        protected void excluirFuncionario(int codigo)
        {
            Models.funcionario funcionario = contexto.funcionario.First(x => x.cd_funcionario == codigo);

            contexto.funcionario.Remove(funcionario);
            contexto.SaveChanges();
            Response.Redirect("listarFuncionario.aspx");
        }

        protected void verificarUsuario(string login, string senha)
        {
            var selecao = contexto.funcionario.FirstOrDefault(x => x.login == login & x.senha == senha);

            if (selecao == null)
                Server.Transfer("login.aspx");
            else
            {
                HttpContext.Current.Session["cd_usuario"] = selecao.cd_funcionario;
                HttpContext.Current.Session["usuario"] = selecao.nm_funcionario;
                HttpContext.Current.Session["tipo"] = selecao.tipo;
                Server.Transfer("ListarAnimal.aspx");
            }
        }
    }
}