﻿using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Bandeira.GerenciadorCampeonatos.WebAPI.Providers;

namespace Bandeira.GerenciadorCampeonatos.WebAPI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            // Para utilizar o Header "Authorization" nas requisições
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            // Ativar o método para gerar o OAuth Token
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
            {
                TokenEndpointPath = new PathString("/Token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            });
        }
    }
}