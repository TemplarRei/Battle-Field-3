namespace BattleField.Logic.Memento
{
    using System;
    using Contracts;

    public class GameSaver: IGameSaver
    {
        private IMemory<IGameInstance> memory;

        public GameSaver()
        {
            this.memory = new GameMemory();
        }

        public IGameInstance RetrieveState(bool previous)
        {
            var save = this.memory.GetState(previous);
            return save;
        }

        public void SaveState(IGameInstance gameToSave)
        {
            this.memory.PushState(gameToSave); //.Save()
        }
    }
}
