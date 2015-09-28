using Bandeira.GerenciadorCampeonatos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Moq;

namespace Bandeira.GerenciadorCampeonatos.Tests.Mocks
{
    public class DbSetMock<T> : IDbSet<T> where T : class
    {
        readonly HashSet<T> set;
        readonly IQueryable<T> queryableSet;

        public DbSetMock()
            : this(Enumerable.Empty<T>())
        { }

        public DbSetMock(IEnumerable<T> entities)
        {
            set = new HashSet<T>();

            foreach (var entity in entities)
            {
                set.Add(entity);
            }

            queryableSet = set.AsQueryable();
        }

        public T Add(T entity)
        {
            set.Add(entity);
            return entity;
        }

        public T Attach(T entity)
        {
            set.Add(entity);
            return entity;
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            throw new NotImplementedException();
        }

        public T Find(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public System.Collections.ObjectModel.ObservableCollection<T> Local
        {
            get { throw new NotImplementedException(); }
        }

        public T Remove(T entity)
        {
            set.Remove(entity);
            return entity;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return set.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Type ElementType
        {
            get { return queryableSet.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return queryableSet.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return queryableSet.Provider; }
        }
    }


    internal class GerenciadorCampeonatosContainerMock : IContainer
    {
        public GerenciadorCampeonatosContainerMock()
        {

            Campeonatos = new DbSetMock<Campeonato>();
            Rodadas = new DbSetMock<Rodada>();
            Partidas = new DbSetMock<Partida>();
            Competidores = new DbSetMock<Competidor>();
            Jogadores = new DbSetMock<Jogador>();
            Pontuacoes = new DbSetMock<Pontuacao>();
            Resultados = new DbSetMock<ResultadoPartida>();
            Locais = new DbSetMock<Local>();
            JogadorCampeonatos = new DbSetMock<JogadorCampeonato>();
        }

        public IDbSet<Campeonato> Campeonatos { get; set; }
        public IDbSet<Rodada> Rodadas { get; set; }
        public IDbSet<Partida> Partidas { get; set; }
        public IDbSet<Competidor> Competidores { get; set; }
        public IDbSet<Jogador> Jogadores { get; set; }
        public IDbSet<Pontuacao> Pontuacoes { get; set; }
        public IDbSet<ResultadoPartida> Resultados { get; set; }
        public IDbSet<Local> Locais { get; set; }
        public IDbSet<JogadorCampeonato> JogadorCampeonatos { get; set; }

        public int SaveChanges()
        {
            return 1;
        }
    }
}
