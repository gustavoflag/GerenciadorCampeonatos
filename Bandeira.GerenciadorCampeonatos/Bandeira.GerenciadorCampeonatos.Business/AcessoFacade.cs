using Bandeira.GerenciadorCampeonatos.Business.Process;
using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public class AcessoFacade : IAcessoFacade
    {
        private PerfilProcess perfilProcess;
        private UsuarioProcess usuarioProcess;

        private IContainer container;

        public AcessoFacade()
            : this(new GerenciadorCampeonatosContainer())
        {
        }

        public AcessoFacade(IContainer container)
        {
            this.container = container;
            perfilProcess = new PerfilProcess(container);
            usuarioProcess = new UsuarioProcess(container);
        }

        //Usuario
        public Resultado CriarUsuario(Usuario usuario)
        {
            Resultado resultado = usuarioProcess.Incluir(usuario);

            if (resultado.Sucesso)
                resultado.Merge(usuarioProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado AlterarUsuario(Usuario usuario)
        {
            Resultado resultado = usuarioProcess.Alterar(usuario);

            if (resultado.Sucesso)
                resultado.Merge(usuarioProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ExcluirUsuario(Usuario usuario)
        {
            Resultado resultado = usuarioProcess.Excluir(usuario);

            if (resultado.Sucesso)
                resultado.Merge(usuarioProcess.SaveChangesContainer());

            return resultado;
        }

        public Usuario ConsultarUsuario(Usuario usuario)
        {
            return usuarioProcess.Consultar(usuario);
        }

        public IList<Usuario> ListarUsuarios()
        {
            return usuarioProcess.Listar();
        }

        public Resultado<Usuario> Login(string login, string senha)
        {
            return usuarioProcess.Login(login, senha);
        }

        //Perfil
        public Resultado CriarPerfil(Perfil perfil)
        {
            Resultado resultado = perfilProcess.Incluir(perfil);

            if (resultado.Sucesso)
                resultado.Merge(perfilProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado AlterarPerfil(Perfil perfil)
        {
            Resultado resultado = perfilProcess.Alterar(perfil);

            if (resultado.Sucesso)
                resultado.Merge(perfilProcess.SaveChangesContainer());

            return resultado;
        }

        public Resultado ExcluirPerfil(Perfil perfil)
        {
            Resultado resultado = perfilProcess.Excluir(perfil);

            if (resultado.Sucesso)
                resultado.Merge(perfilProcess.SaveChangesContainer());

            return resultado;
        }

        public Perfil ConsultarPerfil(Perfil perfil)
        {
            return perfilProcess.Consultar(perfil);
        }

        public IList<Perfil> ListarPerfis()
        {
            return perfilProcess.Listar();
        }
    }
}
