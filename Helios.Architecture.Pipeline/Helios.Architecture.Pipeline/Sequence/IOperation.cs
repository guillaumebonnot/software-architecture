namespace Helios.Architecture.Pipeline.Sequence
{
    public interface IOperation<T>
    {
        void Invoke(T data);
    }
}