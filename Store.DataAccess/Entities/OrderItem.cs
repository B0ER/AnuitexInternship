using Store.DataAccess.Entities.Base;

namespace Store.DataAccess.Entities
{
    public class OrderItem : BaseEntity
    {
        public int Amount { get; set; }
        public int Currency { get; set; }
        public virtual PrintingEdition PrintingEdition { get; set; }
        public int Count { get; set; }
    }
}
