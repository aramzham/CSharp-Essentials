using System;
using System.Reflection;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace CoreFacilities.Serialization.Controlling
{
    [Serializable]
    public class Derived : Base, ISerializable
    {
        private DateTime m_date = DateTime.Now;
        public Derived() { /* Make the type instantiable*/ }

        // If this constructor didn't exist, we'd get a SerializationException
        // This constructor should be protected if this class were not sealed
        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        private Derived(SerializationInfo info, StreamingContext context)
        {
            // Get the set of serializable members for our class and base classes
            var baseType = this.GetType().BaseType;
            var mi = FormatterServices.GetSerializableMembers(baseType, context);
            // Deserialize the base class's fields from the info object
            for (var i = 0; i < mi.Length; i++)
            {
                // Get the field and set it to the deserialized value
                var fi = (FieldInfo)mi[i];
                fi.SetValue(this, info.GetValue(baseType.FullName + "+" + fi.Name, fi.FieldType));
            }
            // Deserialize the values that were serialized for this class
            m_date = info.GetDateTime("Date");
        }

        [SecurityPermissionAttribute(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Serialize the desired values for this class
            info.AddValue("Date", m_date);
            // Get the set of serializable members for our class and base classes
            var baseType = this.GetType().BaseType;
            var mi = FormatterServices.GetSerializableMembers(baseType, context);
            // Serialize the base class's fields to the info object
            for (var i = 0; i < mi.Length; i++)
            {
                // Prefix the field name with the fullname of the base type
                info.AddValue(baseType.FullName + "+" + mi[i].Name,
                    ((FieldInfo)mi[i]).GetValue(this));
            }
        }
        public override string ToString()
        {
            return $"Name={m_name}, Date={m_date}";
        }
    }
}