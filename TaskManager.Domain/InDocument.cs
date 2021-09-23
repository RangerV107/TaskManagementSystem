using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class InDocument
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime RegistrationDate { get; set; } 
        public string MessageText { get; set; }
        public string IncomingNumber { get; set; }



        //Внешние ключи
        public Guid ProductionTaskId { get; set; }

        //Свойства навигации
        public ProductionTask ProductionTask { get; set; }
        public List<Document> Documents { get; set; } = new List<Document>();
        public Person RegistrPerson { get; set; }


    }
}