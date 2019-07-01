using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationTracker.Entities
{
    public abstract partial class BaseEntity<TId> where TId : struct
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public TId Id { get; set; }
    }
}
