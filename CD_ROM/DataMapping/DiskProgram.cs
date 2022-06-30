using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace CD_ROM
{
    [Table(Name = "DiskProgram")]
    public class DiskProgram
    {
        [Column(Name = "ID", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID { get; set; }
        [Column(Name = "Диск")]
        public int Disk { get; set; }
        [Column(Name = "Программа")]
        public int Program { get; set; }
    }
}
