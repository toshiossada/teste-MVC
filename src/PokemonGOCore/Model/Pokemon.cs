using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PokemonGOCore.Model
{
    public class Pokemon
    {
        [Key]
        public int Id { get; set; }       

        public string Name { get; set; }

        public string ImagePath { get; set; }

        public bool CurrentHave { get; set; }

        public int PokemonTypeId { get; set; }
        [ForeignKey("PokemonTypeId")]
        [JsonIgnore]
        public virtual PokemonType PokemonType { get; set; }
    }
}
