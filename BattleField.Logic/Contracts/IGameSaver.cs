using BattleField.Logic.Memento;

namespace BattleField.Logic.Contracts
{
    public interface IGameSaver
    {
        void SaveState(IGameInstance gameToSave);

        IGameInstance RetrieveState(bool previous);
    }
}
