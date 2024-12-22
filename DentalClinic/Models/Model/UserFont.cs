using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class UserFont
    {
        private int _id;
        private string _fontName;

        public UserFont()
        {

        }

        public UserFont(int id, string theme)
        {
            Id = id;
            FontName = theme;
        }

        public int Id { get => _id; init => _id = value; }
        public string FontName { get => _fontName; set => _fontName = value; }
    }
}
