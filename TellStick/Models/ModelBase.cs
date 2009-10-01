using System;
using System.Collections.Generic;
using System.Text;
using TellStick;

namespace TellStick.Models
{
    public abstract class ModelBase
    {
        public abstract Protocols.ProtocolBase Protocol { get; set; }
        public abstract string DisplayName { get; }
        
        protected string _modelName = "";

        public string ModelName
        {
            get
            {
                if (!string.IsNullOrEmpty(_modelName))
                    return _modelName;
                else
                    return ((ModelNameAttribute)this.GetType().GetCustomAttributes(typeof(ModelNameAttribute), false)[0]).Name;
            }
        }
    }
}
