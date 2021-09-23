using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class Document
    {
        public string Title { get; set; }
        public Guid DocumentId { get; set; }
    }
}