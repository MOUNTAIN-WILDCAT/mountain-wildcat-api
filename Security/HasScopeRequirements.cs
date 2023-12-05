using Microsoft.AspNetCore.Authorization;

namespace Emerald.Tiger.Api.Security
{
    public class HasScopeRequirements : IAutorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirements(stringscope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }
        }