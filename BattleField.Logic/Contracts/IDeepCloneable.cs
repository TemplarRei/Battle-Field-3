namespace BattleField.Logic.Contracts
{
    public interface IDeepCloneable<T>
    {
        T DeepClone();
    }
}
