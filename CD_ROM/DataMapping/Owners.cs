using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CD_ROM
{
    [Table(Name = "Owners")]
    public class Owners
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(Name = "Фамилия")]
        public string SecondName { get; set; }
        [Column(Name = "Имя")]
        public string FirstName { get; set; }
        [Column(Name = "Отчество")]
        public string MiddleName { get; set; }
    }
}
