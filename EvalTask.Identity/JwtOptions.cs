﻿namespace EvalTask.Identity
{
    public class JwtOptions
    {

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string SecretPhrase { get; set; }
        
    }
}