using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class ProductionSubTaskDTO : IEntityDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Comments")]
        public string Comments { get; set; }
        [JsonPropertyName("ExecutorReport")]
        public string ExecutorReport { get; set; }
        [JsonPropertyName("PlannedCompletionDate")]
        public DateTime PlannedCompletionDate { get; set; }
        [JsonPropertyName("ActualCompletionDate")]
        public DateTime ActualCompletionDate { get; set; }

        [JsonIgnore]
        private int _State;
        [JsonPropertyName("state")]
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
            //1 – выполняется, 2 – отменено, 3 – выполнено
        }
        [JsonIgnore]
        private int _Priority;
        [JsonPropertyName("priority")]
        public int Priority
        {
            get => _Priority;
            set
            {
                if (0 > value && value > 11)
                    _Priority = 0;
                else
                    _Priority = value;
            }
            //1 – низкий, 5 – нормальный, 7 – вы-сокий, 10 – срочно
        }

        [JsonPropertyName("InitDate")]
        public DateTime InitDate { get; set; }
        [JsonPropertyName("Executor")]
        public PersonDTO Executor { get; set; }
        [JsonPropertyName("ConfirmDate")]
        public DateTime ConfirmDate { get; set; }
        [JsonPropertyName("ReportFlag")]
        public bool ReportFlag { get; set; }
        [JsonPropertyName("TaskReadyFlag")]
        public bool TaskReadyFlag { get; set; }
        [JsonPropertyName("StCancelFlagate")]
        public bool CancelFlag { get; set; }
        [JsonPropertyName("CancelDate")]
        public DateTime CancelDate { get; set; }


        //Внешние ключи
        //...

        //Свойства навигации
        [JsonPropertyName("ProductionTask")]
        public ProductionTaskDTO ProductionTask { get; set; }
        [JsonPropertyName("UpperTask")]
        public ProductionSubTaskDTO UpperTask { get; set; }
        [JsonPropertyName("SubTasks")] 
        public List<Guid> SubTasks { get; set; } = new List<Guid>(); //ProductinSubTaskDTO
        [JsonPropertyName("reportDocs")]
        public List<DocumentDTO> ReportDocs { get; set; } = new List<DocumentDTO>();

    }
}