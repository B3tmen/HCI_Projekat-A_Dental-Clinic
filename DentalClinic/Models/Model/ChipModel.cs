using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ChipModel
    {
        public string Text { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is ChipModel model &&
                   Text == model.Text;
        }

        public static bool operator ==(ChipModel? left, ChipModel? right)
        {
            return EqualityComparer<ChipModel>.Default.Equals(left, right);
        }

        public static bool operator !=(ChipModel? left, ChipModel? right)
        {
            return !(left == right);
        }
    }
}
