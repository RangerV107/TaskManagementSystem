using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class DocumentDTO
    {
        [JsonPropertyName("Title")]
        public string Title { get; set; }
        [JsonPropertyName("DocumentId")]
        public Guid DocumentId { get; set; }
    }
}