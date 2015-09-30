using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    internal abstract class BaseProcess<T> : BaseProcess, IProcess<T> where T : EntityBase
    {
        public BaseProcess(IContainer container)
            : base(container)
        {
        }

        public virtual Resultado Incluir(T obj)
        {
            Resultado resultado = new Resultado();

            resultado = ValidateInsert(obj);

            if (!resultado.Sucesso)
                return resultado;

            try
            {
                Insert(obj);
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
        }

        public virtual Resultado Alterar(T obj)
        {
            Resultado resultado = new Resultado();

            resultado = ValidateUpdate(obj);

            T objBanco = SelectByUnique(obj);

            if (objBanco == null)
            {
                resultado.AddMensagemErro("Objeto não encontrado");
                return resultado;
            }

            try
            {
                Update(objBanco, obj);
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
        }

        public virtual Resultado Excluir(T obj)
        {
            Resultado resultado = new Resultado();

            resultado = ValidateDelete(obj);

            T objBanco = SelectByUnique(obj);

            if (objBanco == null)
            {
                resultado.AddMensagemErro("Objeto não encontrado");
                return resultado;
            }

            try
            {
                Delete(objBanco);
            }
            catch (Exception ex)
            {
                resultado.AddMensagemErro(ex);
            }

            return resultado;
        }

        public virtual T Consultar(T obj)
        {
            return SelectByUnique(obj);
        }

        public virtual IList<T> Listar()
        {
            return Select().ToList();
        }

        protected abstract IQueryable<T> Select();

        protected abstract T SelectByUnique(T obj);

        protected abstract void Insert(T obj);

        protected abstract void Update(T objBanco, T obj);

        protected abstract void Delete(T obj);

        protected abstract Resultado ValidateInsert(T obj);

        protected abstract Resultado ValidateUpdate(T obj);

        protected abstract Resultado ValidateDelete(T obj);
    }

    internal abstract class BaseProcess
    {
        protected IContainer container;

        public BaseProcess()
        {
        }

        public BaseProcess(IContainer container)
        {
            this.container = container;
        }
    }

}
