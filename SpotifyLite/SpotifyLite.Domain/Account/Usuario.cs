﻿using FluentValidation;
using SpotifyLite.CrossCutting.Entity;
using SpotifyLite.CrossCutting.Utils;
using SpotifyLite.Domain.Account.Rules;
using SpotifyLite.Domain.Account.ValueObject;

namespace SpotifyLite.Domain.Account
{
    public class Usuario : Entity<Guid>
    {
        public string Nome { get; set; }
        public Email Email { get; set; }
        public Password Password { get; set; }
        public virtual IList<Playlist> Playlists { get; set; }

        public void SetPassword()
        {
            this.Password.Valor = SecurityUtils.HashSHA1(this.Password.Valor);
        }

        public void Validate() =>
            new UsuarioValidator().ValidateAndThrow(this);
    }
}
