using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class ProductionSubTask
    {
        public Guid Id { get; set; }
        public string Comments { get; set; }
        public string ExecutorReport { get; set; }
        public DateTime PlannedCompletionDate { get; set; }
        public DateTime ActualCompletionDate { get; set; }
        private int _State;
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
        public DateTime InitDate { get; set; }
        public Person Executor { get; set; }
        public DateTime ConfirmDate { get; set; }
        public bool ReportFlag { get; set; }
        public bool TaskReadyFlag { get; set; }
        public bool CancelFlag { get; set; }
        public DateTime CancelDate { get; set; }


        //Внешние ключи
        //...

        //Свойства навигации
        public ProductionTask ProductionTask { get; set; }
        public ProductionSubTask UpperTask { get; set; }
        public List<ProductionSubTask> SubTasks { get; set; } = new List<ProductionSubTask>();
        public List<Document> ReportDocs { get; set; } = new List<Document>();

    }
}