namespace Helios.Architecture.Pipeline.Processors
{
    internal enum OrderStatus
    {
        New,
        Created,
        Priced,
        Payed,
        // final
        Delivered,
        Canceled
    }
}