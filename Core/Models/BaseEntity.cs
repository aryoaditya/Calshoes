using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        [Column(name: "id")]
        public int Id { get; set; }
    }
}