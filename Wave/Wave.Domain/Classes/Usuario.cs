using System.Collections.Generic;

namespace Wave.Domain.Classes
{
    public class Usuario : Base
    {
        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }

        public static Usuario Obter(long id)
        {
            return new Usuario()
            {
                Id = 1,
                Login = "jose",
                Senha = "jose",
                Email = "jose@site.com"
            };
        }

        public static List<Usuario> ObterTodos()
        {
            return new List<Usuario>
            {
                new Usuario()
                {
                    Id = 1,
                    Login = "jose",
                    Senha = "jose",
                    Email = "jose@site.com"
                },
                new Usuario()
                {
                    Id = 2,
                    Login = "maria",
                    Senha = "maria",
                    Email = "maria@site.com"
                },
                new Usuario()
                {
                    Id = 3,
                    Login = "joao",
                    Senha = "joao",
                    Email = "joao@site.com"
                }
            };
        }
    }
}