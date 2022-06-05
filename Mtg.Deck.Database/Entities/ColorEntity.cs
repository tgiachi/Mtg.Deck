using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Deck.Database.Entities
{
    [Table("colors")]
    public class ColorEntity : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<CardEntity> Cards { get; set; }
    }
}
