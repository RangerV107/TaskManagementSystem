using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.API
{
    public interface IEntityDTO
    {
        Guid Id { get; set; }
    }
}
