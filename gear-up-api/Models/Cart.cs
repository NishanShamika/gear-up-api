using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace gear_up_api.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }
        public Order? Order { get; set; }

        public ICollection<CartItem> CartItems { get; set; }
    }
}
