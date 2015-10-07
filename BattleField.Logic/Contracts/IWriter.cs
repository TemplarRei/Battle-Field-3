namespace BattleField.Logic.Contracts
{
    public interface IWriter
    {
        void PrintField(IGameInstance battleField);
        void GameEndMessage(IGameInstance battleField, int moveCounter);
        void PrintString(string str);
    }
}
