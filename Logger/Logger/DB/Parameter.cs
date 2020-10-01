using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logging.Logger.DB
{
    public class Parameter
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string TypeName { get; set; }

        public string Value { get; set; }

        public Parameter()
        {

        }

        public Parameter(string name, object value, Type type)
        {
            Name = name;
            Value = value.ToString();
            TypeName = type.ToString();
        }

        public object GetValue()
        {
            Type type = Type.GetType(TypeName);
            return Convert.ChangeType(Value, type);
        }

    }
}
