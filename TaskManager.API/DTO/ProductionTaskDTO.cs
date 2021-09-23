using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.API.DTO
{
    public class ProductionTaskDTO : IEntityDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("taskContent")]
        public string TaskContent { get; set; }
        [JsonPropertyName("notes")]
        public string Notes { get; set; }
        [JsonPropertyName("initDate")]
        public DateTime InitDate { get; set; }
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
        [JsonPropertyName("docReadyFlag")]
        public bool DocReadyFlag { get; set; }
        [JsonPropertyName("taskReadyFlag")]
        public bool TaskReadyFlag { get; set; }
        [JsonPropertyName("taskCancelFlag")]
        public bool TaskCancelFlag { get; set; }
        [JsonPropertyName("plannedCompletionDate")]
        public DateTime PlannedCompletionDate { get; set; }
        [JsonPropertyName("actualCompletionDate")]
        public DateTime ActualCompletionDate { get; set; }
        [JsonPropertyName("cancelDate")]
        public DateTime CancelDate { get; set; }
        


        //Внешние ключи
        [JsonPropertyName("taskTypeId")]
        public Guid TaskTypeId { get; set; }


        //Свойства навигации
        [JsonPropertyName("executor")]
        public PersonDTO ResponsibleExecutor { get; set; }
        [JsonPropertyName("taskType")]
        public TaskTypeDTO TaskType { get; set; }
        [JsonPropertyName("inputDocs")]
        public InDocumentDTO InputDocs { get; set; }
        [JsonPropertyName("reportDocs")]
        public List<Guid> ReportDocs { get; set; } = new List<Guid>(); //OutDocumentDTO
        [JsonPropertyName("tasks")]
        public List<Guid> Tasks { get; set; } = new List<Guid>(); //ProductinSubTaskDTO
        [JsonPropertyName("completionBasics")]
        public List<DocumentDTO> CompletionBasics { get; set; } = new List<DocumentDTO>();
        [JsonPropertyName("cancellationBasics")]
        public List<DocumentDTO> CancellationBasics { get; set; } = new List<DocumentDTO>();


    }
}
