using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace EcoDim.Core
{
    public abstract class Enumeration
    {
        #region Properties

        public int Value { get; private set; }

        public string DisplayName { get; private set; }

        #endregion

        #region Constructors

        protected Enumeration() { }

        protected Enumeration(int value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        #endregion

        #region Public Methods

        public static bool operator ==(Enumeration entityA, Enumeration entityB)
        {
            if (ReferenceEquals(entityA, null) && ReferenceEquals(entityB, null))
                return true;

            if (ReferenceEquals(entityA, null) || ReferenceEquals(entityB, null))
                return false;

            return entityA.Equals(entityB);
        }

        public static bool operator !=(Enumeration entityA, Enumeration entityB)
        {
            return !(entityA == entityB);
        }

        public virtual int CompareTo(object obj) => Value.CompareTo(((Enumeration)obj).Value);

        public override string ToString()
        {
            return DisplayName;
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = Value.Equals(otherValue.Value);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
        {
            var type = typeof(T);
            var fields = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                var instance = new T();
                var locatedValue = info.GetValue(instance) as T;

                if (locatedValue != null)
                {
                    yield return locatedValue;
                }
            }
        }

        public static IEnumerable GetAll(Type type)
        {
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

            foreach (var info in fields)
            {
                object instance = Activator.CreateInstance(type);
                yield return info.GetValue(instance);
            }
        }

        public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue) => Math.Abs(firstValue.Value - secondValue.Value);

        public static T FromValue<T>(int value) where T : Enumeration, new() => Parse<T, int>(value, "Value", item => item.Value == value);

        public static T FromDisplayName<T>(string displayName) where T : Enumeration, new() => Parse<T, string>(displayName, "Display Name", item => item.DisplayName == displayName);

        #endregion

        #region Private Methods

        private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
        {
            var matchingItem = GetAll<T>().FirstOrDefault(predicate);

            if (matchingItem == null)
            {
                var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
                return null;
            }

            return matchingItem;
        }

        #endregion
    }
}
