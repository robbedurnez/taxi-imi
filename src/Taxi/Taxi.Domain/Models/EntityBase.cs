using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Taxi.Domain
{
    public abstract class EntityBase
    {
        public string Id { get; set; }

        public DateTime? created;
        public DateTime? Created {
            get
            {
                return created ?? DateTime.Now;
            }
            set
            {
                if (value != null)
                    created = value;
                else created = DateTime.Now;
            }
        }

    }
}
