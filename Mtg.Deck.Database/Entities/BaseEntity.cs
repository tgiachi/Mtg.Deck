using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mtg.Deck.Api.Interfaces.Db;

namespace Mtg.Deck.Database.Entities
{
    public class BaseEntity : IBaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime UpdatedDateTime { get; set; }

        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }
}
