namespace BattleField.Logic.Memento
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    internal class GameMemory : IMemory<GameSave>
    {
        private Stack<GameSave> previousStates;
        private Queue<GameSave> revertedStates;

        public GameMemory()
        {
            this.previousStates = new Stack<GameSave>();
            this.revertedStates = new Queue<GameSave>();
        }


        public GameSave GetState(bool isPevious)
        {
            GameSave save = null;

            if (isPevious)
            {
                save = this.previousStates.Pop();
                this.revertedStates.Enqueue(save);
            }
            else
            {
                save = this.revertedStates.Dequeue();
                this.previousStates.Push(save);
            }

            return save;
        }

        public void PushState(GameSave state)
        {
            if (!state.Equals(this.revertedStates.Peek()))
            {
                this.revertedStates.Clear();
            }

            this.previousStates.Push(state);
        }
    }
}