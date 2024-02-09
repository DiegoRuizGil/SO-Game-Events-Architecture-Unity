namespace GameEvents
{
    public interface IGameEventListener<T>
    {
        void OnEventRaise(T item);
    }
}
