using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace VCardMVC.Models
{
    public partial class VCard
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string First { get; set; } = null!;
        [DisplayName("Surname")]
        public string Last { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Gender { get; set; } = null!;
    }
}
