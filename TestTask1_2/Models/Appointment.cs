using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTask1_2.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateEndOfActuality { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
