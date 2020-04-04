namespace Helios.Architecture.Pipeline.Processors
{
    public interface IOperation<T>
    {
        IOperation<T> Next { set; }
        IOperation<T> Terminate { set; }
        void Invoke(T data);
    }
}