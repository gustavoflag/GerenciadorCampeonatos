using System.Collections.Generic;
using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business
{
    public interface IAcessoFacade
    {
        Resultado AlterarPerfil(Perfil perfil);
        Resultado AlterarUsuario(Usuario usuario);
        Perfil ConsultarPerfil(Perfil perfil);
        Usuario ConsultarUsuario(Usuario usuario);
        Resultado CriarPerfil(Perfil perfil);
        Resultado CriarUsuario(Usuario usuario);
        Resultado ExcluirPerfil(Perfil perfil);
        Resultado ExcluirUsuario(Usuario usuario);
        IList<Perfil> ListarPerfis();
        IList<Usuario> ListarUsuarios();
        Resultado Login(string login, string senha);
    }
}