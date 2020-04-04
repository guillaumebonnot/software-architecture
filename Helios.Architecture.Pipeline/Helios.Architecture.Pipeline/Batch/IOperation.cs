namespace Helios.Architecture.Pipeline.Batch
{
    public interface IOperation<T>
    {
        bool Invoke(T data);
    }
}