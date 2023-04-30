using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDDInPractice.Logic
{
    public abstract class Entity
    {
        public virtual long Id { get; protected set; }

        // we over ride .net overide implementation which only uses reference equalities
        public override bool Equals(object obj) 
        {
            //casts the object to an Entity to be validated
            var other = obj as Entity;

            if (ReferenceEquals(other, null))
                return false;

            //if the current Entity is equal with the compared one we will return true
            if (ReferenceEquals(this, other))
                return true;

            //if the current entity is diffent with the refered one return false
            if (GetRealType() != other.GetRealType())
                return false;

            //the entity is not create yet
            if (Id == 0 || other.Id == 0)
                return false;

            //if the entity is the same or equal / identity equality
            return Id == other.Id;
        }

        //uses null comparations
        public static bool operator ==(Entity a, Entity b) {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) {
            return !(a == b);
        }


        //we will generate hash codes for entities with similar IDs
        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        private Type GetRealType()
        { 
            return NHibernate.Proxy.NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }
}
}