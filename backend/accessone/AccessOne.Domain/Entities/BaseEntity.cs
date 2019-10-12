using System.ComponentModel.DataAnnotations.Schema;

namespace AccessOne.Domain.Entities
{
    public abstract class BaseEntity
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }
    }
}
