using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class OutDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string MessageText { get; set; }
        public Person ResponsePerson { get; set; }
        private int _DeliveryType;
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
        public DateTime SentDocsDate { get; set; }
        public string OutgoingNumber { get; set; }
        public Person Executor { get; set; }
        public string ExecutorNumber { get; set; }
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
            //1 – обработка, 2 – ожидает отправ-ки, 3 – отправлено
        }
        public bool SendRespCommand { get; set; }
        public DateTime SendRespCommandDate { get; set; }
        public Person RespCommandPerson { get; set; }
        public DateTime PlannsedRespDate { get; set; }
        public DateTime ActualRespDate { get; set; }
        public string Notes { get; set; }


        //Внешние ключи
        public Guid ProductionTaskId { get; set; }

        //Свойства навигации
        public ProductionTask ProductionTask { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();

    }
}