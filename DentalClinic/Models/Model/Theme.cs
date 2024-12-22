using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class Theme
    {
        private int         _id;
        private ThemeEnum   _theme;

        public Theme()
        {

        }

        public Theme(int id, ThemeEnum theme)
        {
            Id = id;
            ThemeProperty = theme;
        }

        public int          Id              { get => _id; init => _id = value; }
        public ThemeEnum    ThemeProperty   { get => _theme; set => _theme = value; }
    }
}
