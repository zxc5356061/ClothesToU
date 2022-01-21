namespace ClothesToU.Site.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int Subtotal { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool Status { get; set; }

        public bool RequestRefund { get; set; }

        public DateTime RequestRefundTime { get; set; }

        [Required]
        [StringLength(20)]
        public string Recipient { get; set; }

        [Required]
        [StringLength(200)]
        public string ShippingAddress { get; set; }

        [Required]
        [StringLength(10)]
        public string RecipientMobile { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
