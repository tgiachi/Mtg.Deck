using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Deck.Database.Entities
{
    public class ColorCardEntity : BaseEntity
    {
        public Guid CardId { get; set; }
        public virtual CardEntity Card { get; set; }

        public Guid ColorId { get; set; }
        public virtual ColorEntity Color { get; set; }
    }
}
