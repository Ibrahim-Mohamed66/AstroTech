using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AstroTech.Models;

public class Payment
{
    public int Id { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    public String PaymentMethod { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    [Range(1, double.MaxValue, ErrorMessage = "Amount paid must be greater than zero.")]
    public decimal AmountPaid { get; set; }

    [StringLength(100)]
    public string? TransactionId { get; set; } // Optional for payment gateway

    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public String PaymentStatus { get; set; }
    public Order? Order { get; set; }
}