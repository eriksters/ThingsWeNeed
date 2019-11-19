using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwnData.Transactions;

namespace TwnData.Transactions
{
    public class DbTransaction
    {
        public DbTransaction() { 
        
        }

        [Key]
        public int TransactionId { get; set; }

        [Required]
        public string TableName { get; set; }

        [Required]
        public TransactionAction Action { get; set; } 

        [Required]
        public int AffectedId { get; set; }
    }
}
