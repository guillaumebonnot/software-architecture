namespace Helios.Architecture.Pipeline.CircuitBreaker
{
    public interface IOperation<T>
    {
        bool Invoke(T data);
    }
}