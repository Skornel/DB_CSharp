using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CD_ROM
{
    [Table(Name = "Programs")]
    public class Programs
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(Name = "Название")]
        public string Name { get; set; }
    }
}
