using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concat.API.Model
{
    public class HospitalWork
    {
        public int Id { get; set; }

        // Diğer özellikler
        public string WorkName { get; set; }
        public DateTime Date { get; set; }
    }

}
