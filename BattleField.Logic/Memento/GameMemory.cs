namespace BattleField.Logic.Memento
{
    using System;
    using System.Collections.Generic;
    using Contracts;

    internal class GameMemory: IMemory<IGameInstance>
    {
        private Stack<IGameInstance> previousStates;
        private Queue<IGameInstance> revertedStates;

        public GameMemory()
        {
            this.previousStates = new Stack<IGameInstance>();
            this.revertedStates = new Queue<IGameInstance>();
        }

        public IGameInstance GetState(bool isPevious)
        {
            IGameInstance save = null;

            if(isPevious)
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

        public void PushState(IGameInstance state)
        {
            // TODO: Implement a clear future entries upon redo.
            //if(this.revertedStates.Count != 0 && !state.Equals(this.revertedStates.Peek()))
            //{
            //    this.revertedStates.Clear();
            //}

            this.previousStates.Push(state);
        }
    }
}