using System;
using System.Collections.Generic;

#nullable disable

namespace MiraiSystem.Models
{
    public abstract partial class FashionProduct : Product
    {
        public string Colorway { get; set; }
        public string Material { get; set; }
        public string Gender { get; set; }
        public DateTime ReleasedDate { get; set; }
        public string Condition { get; set; }
        public override Brand Brand { get => base.Brand; set => base.Brand = value; }
        public override Category Category { get => base.Category; set => base.Category = value; }
        public override User Creator { get => base.Creator; set => base.Creator = value; }
        public override User Editor { get => base.Editor; set => base.Editor = value; }

        public static readonly string MEN_GENDER = "Men";
        public static readonly string WOMEN_GENDER = "Women";
        public static readonly string YOUTH_GENDER = "Youth";

        public static readonly string USED_CONDITION = "Used";
        public static readonly string DEADSTOCK_CONDITION = "Dead Stock";

        public static bool IsLegalFashionGender(string gender)
        {
            return gender.Equals(MEN_GENDER, StringComparison.OrdinalIgnoreCase) ||
                gender.Equals(WOMEN_GENDER, StringComparison.OrdinalIgnoreCase) ||
                gender.Equals(YOUTH_GENDER, StringComparison.OrdinalIgnoreCase);
        }


    }
}
