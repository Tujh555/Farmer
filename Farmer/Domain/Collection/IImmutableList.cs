namespace Farmer.Domain.Collection
{
    public interface IImmutableList<out T>
    {
        T this[int index]
        {
            get;
        }
        
        int Size { get; }

        void Delete(int index);
    }
}