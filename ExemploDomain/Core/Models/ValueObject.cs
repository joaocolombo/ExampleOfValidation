using System.Collections.Generic;

namespace Core.Models
{
    public abstract class ValueObject
    {
        public List<Error> Erros { get; protected set; }
        public abstract bool EhValido();

        public override bool Equals(object obj)
        {
            var objectValue = obj as ValueObject;
            if (ReferenceEquals(this, objectValue)) return true;
            if (ReferenceEquals(null, objectValue)) return false;
            return false;
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(null, a) && ReferenceEquals(null, b))
            {
                return true;
            }
            if (ReferenceEquals(null, a) || ReferenceEquals(null, b))
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject a, ValueObject b)
        {
            if (a == null && b == null) return false;
            return !a.Equals(b);
        }

        public override int GetHashCode()
        {
            return GetType().GetHashCode() * 688;
        }

        public override string ToString()
        {
            return GetType().Name;
        }

    }
}