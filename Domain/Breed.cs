using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Breed
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<Pet> Pets { get; set; }

    }
}
