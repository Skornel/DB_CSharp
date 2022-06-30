using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CD_ROM
{
    [Table(Name = "Disks")]
    public class Disks
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(Name = "Владелец")]
        public int Owner { get; set; }
        [Column(Name = "Примечание")]
        public string Description { get; set; }
    }
}
