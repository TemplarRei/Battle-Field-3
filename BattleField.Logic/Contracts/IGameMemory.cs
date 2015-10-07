namespace BattleField.Logic.Contracts
{
    public interface IMemory<T>
    {
        T GetState(bool isPrevious);
        void PushState(T state);
    }
}
