using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class IODocument
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
        [JsonPropertyName("RegistrPerson")]
        public Person RegistrPerson { get; set; }
        [JsonPropertyName("MessageText")]
        public string MessageText { get; set; }
        [JsonPropertyName("IncomingNumber")]
        public string IncomingNumber { get; set; }
        [JsonPropertyName("ResponsePerson")]
        public Person ResponsePerson { get; set; }
        [JsonPropertyName("DeliveryType")]
        public int DeliveryType
        {
            get => default;
            set
            {
                DeliveryType = value;
            }
        }
        [JsonPropertyName("SentDocsDate")]
        public DateTime SentDocsDate { get; set; }
        [JsonPropertyName("OutgoingNumber")]
        public string OutgoingNumber { get; set; }
        [JsonPropertyName("Executor")]
        public Person Executor { get; set; }
        [JsonPropertyName("ExecutorNumber")]
        public string ExecutorNumber { get; set; }
        [JsonPropertyName("State")]
        public int State
        {
            get => default;
            set
            {
                State = value;
            }
        }
        [JsonPropertyName("SendRespCommand")]
        public bool SendRespCommand { get; set; }
        [JsonPropertyName("SendRespCommandDate")]
        public DateTime SendRespCommandDate { get; set; }
        [JsonPropertyName("RespCommandPerson")]
        public Person RespCommandPerson { get; set; }
        [JsonPropertyName("PlannsedRespDate")]
        public DateTime PlannsedRespDate { get; set; }
        [JsonPropertyName("ActualRespDate")]
        public DateTime ActualRespDate { get; set; }
        [JsonPropertyName("Notes")]
        public string Notes { get; set; }


        //Внешние ключи
        [JsonPropertyName("ProductionTaskInId")]
        public Guid ProductionTaskInId { get; set; }
        [JsonPropertyName("ProductionTaskRepId")]
        public Guid ProductionTaskRepId { get; set; }

        //Свойства навигации
        [JsonPropertyName("ProductionTaskIn")]
        public ProductionTask ProductionTaskIn { get; set; }
        [JsonPropertyName("ProductionTaskRep")]
        public ProductionTask ProductionTaskRep { get; set; }


    }
}