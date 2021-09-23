using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManager.Domain
{
    public class TaskType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }

        public List<ProductionTask> ProductionTasks { get; set; } = new List<ProductionTask>();
    }
}
