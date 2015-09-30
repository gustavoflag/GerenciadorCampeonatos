using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public class Resultado<T>
    {
        public bool Sucesso { get; private set; }
        public List<string> Mensagens { get; private set; }
        public T Retorno { get; set; }

        public void AddMensagemErro(string mensagem)
        {
            AddMensagem(mensagem);
            Sucesso = false;
        }

        public void AddMensagemErro(Exception exception)
        {
            AddMensagemErro(exception.Message);
            if (exception.InnerException != null)
                AddMensagemErro(exception.InnerException);
        }

        public void AddMensagemSucesso(string mensagem)
        {
            AddMensagem(mensagem);
            Sucesso = true;
        }

        private void AddMensagem(string mensagem)
        {
            if (Mensagens == null)
                Mensagens = new List<string>();

            Mensagens.Add(mensagem);
        }

        public void AddMensagens(List<string> mensagensOther)
        {
            if (Mensagens == null)
                Mensagens = new List<string>();

            if (mensagensOther != null)
                Mensagens.AddRange(mensagensOther);
        }

        public Resultado(Exception exception)
        {
            AddMensagemErro(exception.Message);
        }

        public Resultado()
        {
            Sucesso = true;
        }

        public Resultado<T> Merge(Resultado<T> other)
        {
            Resultado<T> resultadoRetorno = new Resultado<T>();

            resultadoRetorno.Sucesso = this.Sucesso && other.Sucesso;

            resultadoRetorno.AddMensagens(this.Mensagens);
            resultadoRetorno.AddMensagens(other.Mensagens);

            this.AddMensagens(other.Mensagens);
            this.Sucesso = resultadoRetorno.Sucesso;

            if (this.Retorno != null)
            {
                resultadoRetorno.Retorno = this.Retorno;
            }
            else if (other.Retorno != null)
            {
                resultadoRetorno.Retorno = other.Retorno;
                this.Retorno = other.Retorno;
            }
            return resultadoRetorno;
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public string ToString(bool apenasUltima)
        {
            if (Mensagens == null || Mensagens.Count == 0)
            {
                return "Sucesso";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                if (apenasUltima && Mensagens.Count > 0)
                {
                    sb.Append(Mensagens[Mensagens.Count - 1]);
                }
                else
                {
                    foreach (string mensagem in Mensagens.Distinct())
                    {
                        sb.Append(mensagem);
                        sb.Append("<BR>");
                    }
                }
                return sb.ToString();
            }
        }
    }

    public class Resultado : Resultado<int>
    {
        public Resultado(Exception exception)
            : base(exception)
        {

        }

        public Resultado()
            : base()
        {
        }
    }
}
