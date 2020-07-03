using SimpleGameLoop.Infrastructure.StateMachines.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop.Infrastructure.StateMachines.States.GameFlow
{
    public class GameState : IState
    {
        private readonly Game context;

        public bool ExitState { get; set; }

        public GameState(Game context)
        {
            this.context = context;
        }

        public void OnEnter()
        {

        }

        public void Process()
        {
            Console.WriteLine($"{this.GetType().ToString()} Process");
        }

        public void Update()
        {
            Console.WriteLine($"{this.GetType().ToString()} Update ++++++");
        }

        public void Render()
        {
            Console.WriteLine($"{this.GetType().ToString()} Render");
        }

        public void OnExit()
        {
            Console.WriteLine($"{this.GetType().ToString()} OnExit");
        }
    }
}
