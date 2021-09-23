using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class PersonDTO //: IEntityDTO
    {
        //[JsonPropertyName("Id")]
        //public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("UsreId")]
        public Guid UserId { get; set; }


    }
}
