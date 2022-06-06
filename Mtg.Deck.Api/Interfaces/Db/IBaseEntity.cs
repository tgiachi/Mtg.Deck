using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mtg.Deck.Api.Interfaces.Db
{
    public interface IBaseEntity<TId>
    {
        TId Id { get; set; }

        DateTime CreatedDateTime { get; set; }
        DateTime UpdatedDateTime { get; set; }
    }
}
