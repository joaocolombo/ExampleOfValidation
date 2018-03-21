using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Models
{
    public abstract class Entity
    {

        private string id;
        public string Id
        {
            get => id;
            set
            {
                if (!string.IsNullOrEmpty(value))
                    if (string.IsNullOrEmpty(id))
                        id = value;
            }
        }

        public List<Error> Erros { get; protected set; }
        public abstract bool EhValido();

        public override bool Equals(object obj)
        {
            var entity = obj as Entity;
            if (ReferenceEquals(this, entity)) return true;
            if (ReferenceEquals(null, entity)) return false;

            return Id.Equals(entity.Id);
        }

        public static bool operator ==(Entity a, Entity b)
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

        public static bool operator !=(Entity a, Entity b)
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
            return GetType().Name + " Id: " + Id;
        }
    }
}