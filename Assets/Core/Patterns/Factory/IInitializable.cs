namespace Core.Patterns.Factory
{
    public interface IInitializable<V>
    {
        void Initialize(V args);
    }
}

