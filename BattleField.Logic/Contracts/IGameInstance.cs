namespace BattleField.Logic.Contracts
{
    public interface IGameInstance
    {
        int Size { get; set; }
        ICellObject[,] Field { get; set; }
        IFlyweightFactory CellStorage { get; set; }
        void FieldInit();
    }
}
