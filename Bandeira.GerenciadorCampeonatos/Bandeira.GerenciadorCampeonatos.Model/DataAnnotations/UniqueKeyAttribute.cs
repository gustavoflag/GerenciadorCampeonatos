using System;

namespace Bandeira.GerenciadorCampeonatos.Model.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class UniqueKeyAttribute : Attribute
    {
    } 
}
