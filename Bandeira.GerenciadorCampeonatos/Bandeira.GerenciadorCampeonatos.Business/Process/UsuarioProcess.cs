using Bandeira.GerenciadorCampeonatos.Model;
using System.Data.Entity;
using System.Linq;
using System.Web.Helpers;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class UsuarioProcess : BaseProcess<Usuario>
    {
        public UsuarioProcess(IContainer container) 
            : base(container)
        {
            this.container = container;
        }

        public UsuarioProcess()
            : base(new GerenciadorCampeonatosContainer())
        {
            
        }

        protected override void Delete(Usuario obj)
        {
            container.Usuarios.Remove(obj);
        }

        protected override void Insert(Usuario obj)
        {
            obj.Senha = Crypto.HashPassword(obj.Senha);

            container.Usuarios.Add(obj);
        }

        protected override IQueryable<Usuario> Select()
        {
            return container.Usuarios.Include("Perfil");
        }

        protected override Usuario SelectByUnique(Usuario obj)
        {
            return Select().Where(u => u.UsuarioId == obj.UsuarioId).FirstOrDefault();
        }

        protected override void Update(Usuario objBanco, Usuario obj)
        {
            objBanco.Login = obj.Login;

            if (!string.IsNullOrEmpty(obj.Senha))
                objBanco.Senha = Crypto.HashPassword(obj.Senha);

            objBanco.PerfilId = obj.PerfilId;
        }

        protected override Resultado ValidateDelete(Usuario obj)
        {
            return new Resultado();
        }

        protected override Resultado ValidateInsert(Usuario obj)
        {
            Resultado resultado = new Resultado();

            if (container.Usuarios.Any(c => c.Login == obj.Login && c.UsuarioId != obj.UsuarioId))
                resultado.AddMensagemErro("Já existe outro usuário com esse Login");

            if (obj.Login == null || obj.Login.Length < 4)
                resultado.AddMensagemErro("Campo Login deve ter ao menos 4 caracteres.");

            return resultado;
        }

        protected override Resultado ValidateUpdate(Usuario obj)
        {
            Resultado resultado = new Resultado();

            if (container.Usuarios.Any(c => c.Login == obj.Login && c.UsuarioId != obj.UsuarioId))
                resultado.AddMensagemErro("Já existe outro usuário com esse Login");

            if (obj.Login.Length < 4)
                resultado.AddMensagemErro("Campo Login deve ter ao menos 4 caracteres.");

            return resultado;
        }

        internal Resultado<Usuario> Login(string login, string senha)
        {
            Resultado<Usuario> resultado = new Resultado<Usuario>();

            if (string.IsNullOrEmpty(login))
            {
                resultado.AddMensagemErro("Login é obrigatório");
            }

            if (string.IsNullOrEmpty(senha))
            {
                resultado.AddMensagemErro("Senha é obrigatório");
            }

            if (resultado.Sucesso)
            { 
                Usuario usuario = Select().Where(u => u.Login == login).AsNoTracking().FirstOrDefault();

                if (usuario == null)
                {
                    resultado.AddMensagemErro("Usuário não encontrado");
                }
                else
                {
                    if (!Crypto.VerifyHashedPassword(usuario.Senha, senha))
                    {
                        resultado.AddMensagemErro("Senha incorreta");
                    }
                }

                if (resultado.Sucesso)
                {
                    resultado.Retorno = usuario;
                }
            }

            return resultado;
        }
    }
}
