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
            NewGameSelected = false;
        }

        public void Tick()
        {
            // TODO: Call menu entities Update and Render methods
        }

        public void OnExit()
        {

        }
    }
}
