using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class InDocumentDTO : IEntityDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("DeliveryDate")]
        public DateTime DeliveryDate { get; set; }
        [JsonPropertyName("RegistrationDate")]
        public DateTime RegistrationDate { get; set; }
        [JsonPropertyName("MessageText")]
        public string MessageText { get; set; }
        [JsonPropertyName("IncomingNumber")]
        public string IncomingNumber { get; set; }



        //Внешние ключи
        [JsonPropertyName("ProductionTaskId")]
        public Guid ProductionTaskId { get; set; }
        [JsonPropertyName("RegistrPersonId")]
        public Guid RegistrPersonId { get; set; }

        //Свойства навигации
        [JsonPropertyName("ProductionTask")]
        public ProductionTaskDTO ProductionTask { get; set; }
        [JsonPropertyName("Documents")]
        public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();
        [JsonPropertyName("RegistrPerson")]
        public PersonDTO RegistrPerson { get; set; }


    }
}