using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.TranslationSpace
{
    public class Language
    {
        public string Code { get; set; } = string.Empty; // "en", "ru", "fr"
        public string Name { get; set; } = string.Empty; // "English", "Русский", "Français"

    }
}
