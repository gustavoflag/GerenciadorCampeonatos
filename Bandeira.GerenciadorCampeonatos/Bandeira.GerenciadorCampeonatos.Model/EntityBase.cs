using System;
using System.Collections.Generic;

namespace Bandeira.GerenciadorCampeonatos.Model
{
    public abstract partial class EntityBase : ICloneable
    {
        public int Id { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
