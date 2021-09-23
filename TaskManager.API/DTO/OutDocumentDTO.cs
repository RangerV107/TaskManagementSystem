using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class OutDocumentDTO : IEntityDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Address")]
        public string Address { get; set; }
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [JsonPropertyName("MessageText")]
        public string MessageText { get; set; }
        [JsonPropertyName("ResponsePerson")]
        public PersonDTO ResponsePerson { get; set; }
        [JsonIgnore]
        private int _DeliveryType;
        [JsonPropertyName("DeliveryType")]
        public int DeliveryType
        {
            get => _DeliveryType;
            set
            {
                if (0 > value && value > 4)
                    _DeliveryType = 0;
                else
                    _DeliveryType = value;
            }
            //1 – обычное письмо, 2 – заказное письмо, 3 – курьер
        }
        [JsonPropertyName("SentDocsDate")]
        public DateTime SentDocsDate { get; set; }
        [JsonPropertyName("OutgoingNumber")]
        public string OutgoingNumber { get; set; }
        [JsonPropertyName("Executor")]
        public PersonDTO Executor { get; set; }
        [JsonPropertyName("ExecutorNumber")]
        public string ExecutorNumber { get; set; }
        [JsonIgnore]
        private int _State;
        [JsonPropertyName("State")]
        public int State
        {
            get => _State;
            set
            {
                if (0 > value && value > 4)
                    _State = 0;
                else
                    _State = value;
            }
            //1 – обработка, 2 – ожидает отправ-ки, 3 – отправлено
        }
        [JsonPropertyName("SendRespCommand")]
        public bool SendRespCommand { get; set; }
        [JsonPropertyName("SendRespCommandDate")]
        public DateTime SendRespCommandDate { get; set; }
        [JsonPropertyName("RespCommandPerson")]
        public PersonDTO RespCommandPerson { get; set; }
        [JsonPropertyName("PlannsedRespDate")]
        public DateTime PlannsedRespDate { get; set; }
        [JsonPropertyName("ActualRespDate")]
        public DateTime ActualRespDate { get; set; }
        [JsonPropertyName("Notes")]
        public string Notes { get; set; }


        //Внешние ключи
        [JsonPropertyName("ProductionTaskId")]
        public Guid ProductionTaskId { get; set; }

        //Свойства навигации
        [JsonPropertyName("ProductionTask")]
        public ProductionTaskDTO ProductionTask { get; set; }
        [JsonPropertyName("Documents")]
        public List<DocumentDTO> Documents { get; set; } = new List<DocumentDTO>();

       
    }
}