namespace Helios.Architecture.Pipeline.Batch
{
    class Result<T>
    {
        public readonly T Data;
        public bool Success { get; private set; } = true;
        public void Fail() => Success = false;

        public Result(T data)
        {
            Data = data;
        }
    }
}