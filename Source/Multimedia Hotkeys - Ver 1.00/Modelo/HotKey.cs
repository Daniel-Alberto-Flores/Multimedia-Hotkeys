using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    [Table("HotKeys")]
    public class HotKey
    {
        [Key]
        [DisplayName("Name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }

        [DisplayName("Modifier")]
        [Required]
        public string Modifier { get; set; }

        [DisplayName("Key")]
        [Required]
        public string Key { get; set; }

        public HotKey (string name, string modifier, string key)
        {
            Name = name;
            Modifier = modifier;
            Key = key;
        }
    }
}
