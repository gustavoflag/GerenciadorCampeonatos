using System.Collections.Generic;
using Bandeira.GerenciadorCampeonatos.Model;

namespace Bandeira.GerenciadorCampeonatos.Business.Process
{
    public interface IProcess<T>
    {
        Resultado Incluir(T obj);
       
        Resultado Alterar(T obj);
       
        Resultado Excluir(T obj);
       
        T Consultar(T obj);
        
        IList<T> Listar();
    }
}
