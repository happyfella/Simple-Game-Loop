using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop.Infrastructure.StateMachines.Interface
{
    public interface IState
    {
        void OnEnter();
        void Tick();
        void OnExit();
    }
}
