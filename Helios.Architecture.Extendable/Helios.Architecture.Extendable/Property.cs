using System;

namespace Helios.Architecture.Extendable
{
    public abstract class Property<T>
    {
        public readonly string Name;
        public readonly Type Type;

        public int Index { get; internal set; }

        protected Property(string name, Type type)
        {
            Name = name;
            Type = type;
        }
    }

    public class Property<TInstance, TProperty> : Property<TInstance> where TInstance : ExtendableObject<TInstance>
    {
        public Property(string name) : base(name, typeof(TProperty))
        {
        }

        public TProperty Get(TInstance instance)
        {
            return instance.GetProperty(this);
        }

        public void Set(TInstance instance, TProperty value)
        {
            instance.SetProperty(this, value);
        }
    }
}
