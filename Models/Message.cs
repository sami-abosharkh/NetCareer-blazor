using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class Message
    {
        public int Id { get; set; }

        public required string SenderID { get; set; }
        [ForeignKey("SenderID")]
        public ApplicationUser? Sender { get; set; }
        public required string ReceiverID { get; set; }
        [ForeignKey("ReceiverID")]
        public ApplicationUser? Receiver { get; set; }
        [Required, MaxLength(250)]
        public required string Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
