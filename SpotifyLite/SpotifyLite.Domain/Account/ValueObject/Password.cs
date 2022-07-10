namespace SpotifyLite.Domain.Account.ValueObject
{
    public class Password
    {
        public Password()
        {

        }
        public Password(string valor)
        {
            this.Valor = valor ?? throw new ArgumentNullException(nameof(Password));
        }

        public string Valor { get; set; }
    }
}
