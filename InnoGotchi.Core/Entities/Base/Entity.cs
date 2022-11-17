using System.ComponentModel.DataAnnotations;

namespace InnoGotchi.Core.Entities.Base
{
    public class Entity : EntityBase<int>
    {
        [Key]
        public override int Id { get; protected set; }
    }
}
