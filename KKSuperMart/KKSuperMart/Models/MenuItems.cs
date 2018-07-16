using System;
using Xamarin.Forms;

namespace KKSuperMart.Models
{
    public class MenuItems:BaseModel
    {
        public int Index { get; set; }
        public string IconSource { get; set; }
        public string Name { get; set; }
        public SeparatorVisibility IsSeperatorVisible { get; set; }
        public Type TargetType { get; set; }
    }
}
