using SimpleGameLoop.Infrastructure.StateMachines.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop.Infrastructure.StateMachines.States.GameFlow
{
    public class SplashState : IState
    {
        private readonly Game context;

        public bool ExitState { get; set; }

        public SplashState(Game context)
        {
            this.context = context;
        }

        public void OnEnter()
        {

        }

        public void Tick()
        {
            // TODO: Call splash entities Update and Render methods
        }

        public void OnExit()
        {

        }
    }
}
