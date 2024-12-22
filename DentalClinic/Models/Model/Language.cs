using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Language
    {
        private int             _id;
        private LanguageEnum    _language;

        public Language() { }

        public Language(int id, LanguageEnum language)
        {
            Id = id;
            LanguageProperty = language;
        }

        public int          Id                  { get => _id; init => _id = value; }
        public LanguageEnum LanguageProperty    { get => _language; set => _language = value; }
    }
}
