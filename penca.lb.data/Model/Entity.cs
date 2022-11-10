using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace penca.lb.data.Model
{
    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual long Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }

        public Entity()
        {
        }
    }
}