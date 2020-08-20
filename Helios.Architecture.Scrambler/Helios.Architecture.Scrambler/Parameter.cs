namespace Helios.Architecture.Scrambler
{
    public class Parameter<T>
    {
        public readonly string Name;
        public T Data;

        public Parameter(string name) => Name = name;
        public Parameter(string name, T data) : this(name)
        {
            Data = data;
        }

        public override string ToString()
        {
            return Data.ToString();
        }

        public static implicit operator T(Parameter<T> parameter)
        {
            return parameter.Data;
        }
    }
}