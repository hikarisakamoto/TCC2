using System;
using System.Linq;
using FluentValidation.Results;

namespace Sakamoto.TCC2.CSU.Domain.Core.Models
{
    public abstract class ValueObject<TValueObject> : IEquatable<TValueObject>
        where TValueObject : ValueObject<TValueObject>
    {
        public ValidationResult ValidationResult { get; protected set; }

        public bool Equals(TValueObject other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            // Compare all public properties
            var publicProperties = GetType().GetProperties();

            if (!(publicProperties != null
                  &&
                  publicProperties.Any()))
                return true;

            return publicProperties.All(pp =>
            {
                var left = pp.GetValue(this, null);
                var right = pp.GetValue(other, null);

                if (!typeof(TValueObject).IsAssignableFrom(left.GetType())) return left.Equals(right);

                // Check not self-references...
                return ReferenceEquals(left, right);
            });
        }

        public abstract bool IsValid();

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (ReferenceEquals(this, obj)) return true;

            var item = obj as ValueObject<TValueObject>;

            if (item == null) return false;

            return Equals((TValueObject) item);
        }

        public override int GetHashCode()
        {
            var hashCode = 31;
            var changeMultiplier = false;
            const int index = 1;

            // Compare all public proprieties
            var publicProperties = GetType().GetProperties();

            if (publicProperties != null
                &&
                publicProperties.Any())
                foreach (var property in publicProperties)
                {
                    var value = property.GetValue(this, null);

                    if (value != null)
                    {
                        hashCode = hashCode * (changeMultiplier ? 59 : 114) + value.GetHashCode();
                        changeMultiplier = !changeMultiplier;
                    }
                    else
                    {
                        // Only for support {"a",null,null,"a"} <> {null,"a","a",null}
                        hashCode ^= index * 13;
                    }
                }

            return hashCode;
        }

        public static bool operator ==(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            if (Equals(left, null)) return Equals(right, null);

            return left.Equals(right);
        }

        public static bool operator !=(ValueObject<TValueObject> left, ValueObject<TValueObject> right)
        {
            return !(left == right);
        }
    }
}