namespace SignalR.IdentityServer
{
    using IdentityServer4.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Config
    {
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "Cliente1",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // acceso del cliente mediante credenciales
                    ClientSecrets =
                    {
                        new Secret("KeySecret".Sha256()) // clave que se le da al cliente para que se conecte
                    },
                    AllowedScopes = { "resourceApi1" } // el cliente solo tiene acceso a el recurso resourceApi1
                },
                new Client
                {
                    ClientId = "Cliente2",
                    AllowedGrantTypes = GrantTypes.ClientCredentials, // acceso del cliente mediante credenciales
                    ClientSecrets =
                    {
                        new Secret("KeySecret".Sha256()) // clave que se le da al cliente para que se conecte
                    },
                    AllowedScopes = { "resourceApi1" } // el cliente solo tiene acceso a el recurso resourceApi1
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("resourceApi1", "Primer Recurso de Prueba")
            };
        }
    }
}
