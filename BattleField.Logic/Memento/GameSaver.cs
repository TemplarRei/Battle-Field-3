namespace BattleField.Logic.Memento
{
    using System;
    using Contracts;

    class GameSaver :IGameSaver
    {
        private IMemory<GameSave> memory;

        public GameSaver()
        {
            this.memory = new GameMemory();
        }

        public IGameInstance RetrieveState(bool previous)
        {
            throw new NotImplementedException();
        }

        public void SaveState(IGameInstance gameToSave)
        {
            throw new NotImplementedException();
        }
    }
}
