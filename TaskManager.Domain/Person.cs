using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace TaskManager.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
