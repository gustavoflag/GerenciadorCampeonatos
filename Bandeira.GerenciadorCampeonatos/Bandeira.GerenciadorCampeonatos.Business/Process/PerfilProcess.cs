using Bandeira.GerenciadorCampeonatos.Model;
using System.Linq;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal class PerfilProcess : BaseProcess<Perfil>
    {
        public PerfilProcess(IContainer container) 
            : base(container)
        {
            this.container = container;
        }

        public PerfilProcess()
             : base(new GerenciadorCampeonatosContainer())
        {

        }

        protected override void Delete(Perfil obj)
        {
            container.Perfis.Remove(obj);
        }

        protected override void Insert(Perfil obj)
        {
            container.Perfis.Add(obj);
        }

        protected override IQueryable<Perfil> Select()
        {
            return container.Perfis;
        }

        protected override Perfil SelectByUnique(Perfil obj)
        {
            return Select().Where(p => p.PerfilId == obj.PerfilId).FirstOrDefault();
        }

        protected override void Update(Perfil objBanco, Perfil obj)
        {
            objBanco.Nome = obj.Nome;
            objBanco.PermissaoAcesso = obj.PermissaoAcesso;
            objBanco.PermissaoCampeonato = obj.PermissaoCampeonato;
            objBanco.PermissaoPartida = obj.PermissaoPartida;
        }

        protected override Resultado ValidateDelete(Perfil obj)
        {
            Resultado resultado = new Resultado();

            if (container.Usuarios.Any(u => u.PerfilId == obj.PerfilId))
                resultado.AddMensagemErro("Não é possível excluir esse perfil, ele possui usuários associados á ele.");

            return resultado;
        }

        protected override Resultado ValidateInsert(Perfil obj)
        {
            Resultado resultado = new Resultado();

            if (container.Perfis.Any(c => c.Nome == obj.Nome && c.PerfilId != obj.PerfilId))
                resultado.AddMensagemErro("Já existe outro perfil com esse Nome");

            return resultado;
        }

        protected override Resultado ValidateUpdate(Perfil obj)
        {
            Resultado resultado = new Resultado();

            if (container.Perfis.Any(c => c.Nome == obj.Nome && c.PerfilId != obj.PerfilId))
                resultado.AddMensagemErro("Já existe outro perfil com esse Nome");

            return resultado;
        }
    }
}
