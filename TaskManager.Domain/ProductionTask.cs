using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class ProductionTask
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string TaskContent { get; set; }
        public string Notes { get; set; }
        public DateTime InitDate { get; set; }
        private int _State;
        public int State
        {
            get => _State;
            set
            {
                if(0 > value && value > 4)
                    _State = 0;
                else
                    _State = value;
            }
            //1 – выполняется, 2 – отменено, 3 – выполнено
        }
        private int _Priority;
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
        public bool DocReadyFlag { get; set; }
        public bool TaskReadyFlag { get; set; }
        public bool TaskCancelFlag { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
        public DateTime CancelDate { get; set; }
        


        //Внешние ключи
        public Guid TaskTypeId { get; set; }


        //Свойства навигации
        public Person ResponsibleExecutor { get; set; }
        public TaskType TaskType { get; set; }
        public InDocument InputDocs { get; set; }
        public List<OutDocument> ReportDocs { get; set; } = new List<OutDocument>();
        public List<ProductionSubTask> Tasks { get; set; } = new List<ProductionSubTask>();
        public List<Document> CompletionBasics { get; set; } = new List<Document>();
        public List<Document> CancellationBasics { get; set; } = new List<Document>();

    }
}
