using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Deck.Database.Entities
{

    [Table("rarity")]
    public class RarityEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
