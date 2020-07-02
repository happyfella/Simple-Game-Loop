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
            Console.WriteLine($"{this.GetType()} State OnEnter");
        }

        public void Tick()
        {
            Console.WriteLine($"{this.GetType()} State Tick");

            // TODO: Call game entities Update and Render methods
        }

        public void OnExit()
        {
            Console.WriteLine($"{this.GetType()} State OnExit");
        }
    }
}
