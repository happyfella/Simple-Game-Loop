using SimpleGameLoop.Infrastructure.StateMachines.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop.Infrastructure.StateMachines.States.GameFlow
{
    public class MainMenuState : IState
    {
        private readonly Game context;

        public bool NewGameSelected { get; set; }

        public MainMenuState(Game context)
        {
            this.context = context;
        }

        public void OnEnter()
        {
            Console.WriteLine($"{this.GetType().ToString()} OnEnter");
            NewGameSelected = false;
        }

        public void Process()
        {
            Console.WriteLine($"{this.GetType().ToString()} Process");
        }

        public void Update()
        {
            Console.WriteLine($"{this.GetType().ToString()} Update");
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
