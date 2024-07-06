using Domain.Common;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
        public int Population { get; set; }

    }
}
