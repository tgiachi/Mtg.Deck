using System.ComponentModel.DataAnnotations.Schema;

namespace Mtg.Deck.Database.Entities
{

    [Table("cards")]
    public class CardEntity : BaseEntity
    {
        public string CardName { get; set; }

        public string ManaCost { get; set; }

        public int TotalManaCosts { get; set; }

        public int? MtgId { get; set; }

        public decimal? Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public virtual List<ColorEntity> Colors { get; set; }

        public virtual CardTypeEntity CardType { get; set; }

    }
}
