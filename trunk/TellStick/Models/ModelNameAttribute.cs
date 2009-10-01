using System;
using System.Collections.Generic;
using System.Text;

namespace TellStick.Models
{
    public class ModelNameAttribute : Attribute
    {
        private string _name;
        private bool _hide;

        public string Name { get { return _name; } }
        public bool HideInList { get { return _hide; } }

        public ModelNameAttribute(string name)
            : this(name, true) { }

        public ModelNameAttribute(string name, bool hide)
        {
            _name = name;
            _hide = hide;
        }
    }
}
