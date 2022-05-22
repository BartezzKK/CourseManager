using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CourseManager.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        [Required]
        [DisplayName("Payment date")]
        public DateTime PaymentDate { get; set; }
        [DisplayName("End of access")]
        public DateTime EndSubscription { get; set; }

    }
}
