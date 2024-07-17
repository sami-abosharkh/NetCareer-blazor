using System.ComponentModel.DataAnnotations.Schema;

namespace NetCareer.Models
{
    public class Message
    {
        public int ID { get; set; }

        public int SenderID { get; set; }
        [ForeignKey("SenderID")]
        public ApplicationUser? Sender { get; set; }

        public int ReceiverID { get; set; }
        [ForeignKey("ReceiverID")]
        public ApplicationUser? Receiver { get; set; }

        public string? Content { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
