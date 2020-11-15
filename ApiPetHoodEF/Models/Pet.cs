using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPetHoodEF.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string NomeUsuario { get; set; }
        public string Whatsapp { get; set; }
        public string Localizacao { get; set; }
        public string NomePet { get; set; }
        public string Especie { get; set; }
        public Breed Raca { get; set; }
        public int RacaId { get; set; }
        public string Sexo { get; set; }
        public string Foto { get; set; }
        public string PorteFisico { get; set; }
        public string Biografia { get; set; }
        public bool InfoEmail { get; set; }
    }
}
