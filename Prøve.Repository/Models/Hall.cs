using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prøve.Repository.Models
{
    public class Hall
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public List<Seat> seats { get; set; }
    }
}
