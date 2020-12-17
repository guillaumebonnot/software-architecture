namespace Helios.Architecture.Pipeline.Compiled
{
    public class Parameter<T>
    {
        public T Data;

        public Parameter(T data)
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