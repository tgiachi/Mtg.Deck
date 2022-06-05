using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Deck.Database.Entities
{

    [Table("cards")]
    public class CardEntity : BaseEntity
    {
        public string CardName { get; set; }

        public int TotalManaCosts { get; set; }

        public virtual List<ColorEntity> Colors { get; set; }

        public virtual CardTypeEntity CardType { get; set; }
    }
}
