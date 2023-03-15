using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassBook.Models
{
    public class Transaction
    {
        [Key]
        public int  TransactionId{get;set;}
        [Column(TypeName ="nVarchar(12)")]
        [DisplayName("Account Number")]
        [Required(ErrorMessage =("This field is required."))]
        [MaxLength(12,ErrorMessage =("Maximum 12 characters only."))]
        public String  AccountNumber { get; set; }
        [Column(TypeName = "nVarchar(100)")]
        [DisplayName("Benificiary Name")]
        [Required(ErrorMessage = ("This field is required."))]
        [MaxLength(100, ErrorMessage = ("Maximum 100 characters only."))]
        public String BenificiaryName { get; set; }
        [Column(TypeName = "nVarchar(100)")]
        [DisplayName("BankName")]
        [Required(ErrorMessage = ("This field is required."))]
        [MaxLength(100, ErrorMessage = ("Maximum 100 characters only."))]
        public String BankName { get; set; }
        [Column(TypeName = "nVarchar(12)")]
        [DisplayName("SWIFT Code")]
        [Required(ErrorMessage = ("This field is required."))]
        [MaxLength(11, ErrorMessage = ("Maximum 11 characters only."))]
        public String SWIFTCode { get; set; }
        //[Required(ErrorMessage = ("This field is required."))]
        public int Amount { get; set; }
        [DisplayFormat(DataFormatString ="{00:MM-dd-yy}")]
        public DateTime Date { get; set; }



    }
}
