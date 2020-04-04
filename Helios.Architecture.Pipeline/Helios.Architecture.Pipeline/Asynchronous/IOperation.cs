namespace Helios.Architecture.Pipeline.Asynchronous
{
    public interface IOperation<T>
    {
        void SetNext(IOperation<T> next);
        void Invoke(T data);
    }
}