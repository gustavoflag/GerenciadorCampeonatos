﻿using AutoMapper;
using Bandeira.GerenciadorCampeonatos.Business;
using Bandeira.GerenciadorCampeonatos.Model;
using Bandeira.GerenciadorCampeonatos.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bandeira.GerenciadorCampeonatos.WebAPI.Controllers
{
    [Authorize]
    public class UsuarioController : ApiController
    {
        private IAcessoFacade acessoFacade;

        public UsuarioController()
        {
            acessoFacade = new AcessoFacade();
        }

        // GET api/usuario
        public IList<UsuarioViewList> Get()
        {
            return Mapper.Map<IList<Usuario>, IList<UsuarioViewList>>(acessoFacade.ListarUsuarios());
        }

        // GET api/usuario/5
        public UsuarioView Get(int usuarioId)
        {
            return Mapper.Map<UsuarioView>(acessoFacade.ConsultarUsuario(new Usuario() { UsuarioId = usuarioId }));
        }

        // POST api/usuario
        public Resultado Post([FromBody]UsuarioView usuario)
        {
            return acessoFacade.CriarUsuario(Mapper.Map<Usuario>(usuario));
        }

        // PUT api/usuario/5
        public Resultado Put(int id, [FromBody]UsuarioView usuario)
        {
            usuario.UsuarioId = id;

            return acessoFacade.AlterarUsuario(Mapper.Map<Usuario>(usuario));
        }

        // DELETE api/values/5
        public Resultado Delete(int id)
        {
            return acessoFacade.ExcluirUsuario(new Usuario() { UsuarioId = id });
        }
    }
}