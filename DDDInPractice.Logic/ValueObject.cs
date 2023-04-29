﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public abstract class ValueObject<T> where T :ValueObject<T>
    {
        public override bool Equals(object obj)
        {
            var valueObjet = obj as T;

            if (ReferenceEquals(valueObjet, null))
                return false;

            return EqualScore(valueObjet);
        }

        public abstract bool EqualScore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();

        public static bool operator ==(ValueObject<T> a, ValueObject<T> b) {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;
            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b) {
            return !(a == b);
        }
    }
}