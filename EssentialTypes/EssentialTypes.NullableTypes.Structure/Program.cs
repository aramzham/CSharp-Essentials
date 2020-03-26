using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EssentialTypes.NullableTypes.Structure
{
    [Serializable, StructLayout(LayoutKind.Sequential)]
    public struct Nullable<T> where T : struct
    {
        // These 2 fields represent the state
        private Boolean hasValue; // Assume null
        internal T value; // Assume all bits zero

        public Nullable(T value)
        {
            this.value = value;
            this.hasValue = true;
        }
        public Boolean HasValue { get { return hasValue; } }
        public T Value
        {
            get
            {
                if (!hasValue)
                {
                    throw new InvalidOperationException(
                    "Nullable object must have a value.");
                }
                return value;
            }
        }
        public T GetValueOrDefault() { return value; }
        public T GetValueOrDefault(T defaultValue)
        {
            if (!HasValue) return defaultValue;
            return value;
        }
        public override Boolean Equals(Object other)
        {
            if (!HasValue) return (other == null);
            if (other == null) return false;
            return value.Equals(other);
        }
        public override int GetHashCode()
        {
            if (!HasValue) return 0;
            return value.GetHashCode();
        }
        public override string ToString()
        {
            if (!HasValue) return "";
            return value.ToString();
        }
        public static implicit operator Nullable<T>(T value)
        {
            return new Nullable<T>(value);
        }
        public static explicit operator T(Nullable<T> value)
        {
            return value.Value;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Nullable<int> a = new Nullable<int>(2);
            Console.WriteLine(a.GetValueOrDefault());
        }
    }
}
