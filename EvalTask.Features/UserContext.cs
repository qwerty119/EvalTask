using System;

namespace EvalTask.Features
{
    public class UserContext
    {
        public UserContext(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
        
    }
}