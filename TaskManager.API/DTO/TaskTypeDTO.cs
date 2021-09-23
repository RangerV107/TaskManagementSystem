using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskManager.API.DTO
{
    public class TaskTypeDTO : IEntityDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public int Code { get; set; }

        [JsonPropertyName("productionTasks")]
        //public List<ProductionTaskDTO> ProductionTasks { get; set; } = new List<ProductionTaskDTO>();
        public List<Guid> ProductionTasks { get; set; } = new List<Guid>();
    }
}
