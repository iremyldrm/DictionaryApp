using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DictionaryApp.Models
{
    public partial class Keywords
    {
        [Key]
        public int Id { get; set; }
        [Column("Word_En")]
        public string WordEn { get; set; }
        [Column("Word_Tr")]
        public string WordTr { get; set; }
    }
}
