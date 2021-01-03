using System;

namespace EvalTask.Domain.Interfaces
{
    public interface IAuditable
    {
        DateTime CreatedDate { get; set; }
        
        DateTime? UpdatedDate { get; set; }
        
        string CreatedByUserId { get; set; }
        
        string UpdatedByUserId { get; set; }
    }
}