using SimpleGameLoop.Infrastructure.StateMachines.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop.Infrastructure.StateMachines
{
    public class GeneralStateMachine
    {
        private IState CurrentState;

        // All Transitions
        private Dictionary<Type, List<Transition>> Transitions = new Dictionary<Type, List<Transition>>();

        // THe CurrentTransitions available
        private List<Transition> CurrentTransitions = new List<Transition>();
        
        // Transitions that will execute out of sequence with CurrentTransitions
        private List<Transition> InstantTransitions = new List<Transition>();

        // Used to over write the transition lists
        private List<Transition> EmptyTransitions = new List<Transition>();

        public void Tick()
        {
            var transition = GetTransition();
            if(transition != null)
            {
                SetState(transition.To);
            }
        }

        public void Process()
        {
            CurrentState.Process();
        }

        public void Update()
        {
            CurrentState.Update();
        }

        public void Render()
        {
            CurrentState.Render();
        }

        public void SetState(IState state)
        {
            if(CurrentState == state)
            {
                return;
            }

            CurrentState?.OnExit();
            CurrentState = state;

            // Fill CurrentTransitions using the new CurrentState as the key.
            Transitions.TryGetValue(CurrentState.GetType(), out CurrentTransitions);
            if(CurrentTransitions == null)
            {
                CurrentTransitions = EmptyTransitions;
            }

            CurrentState.OnEnter();
        }

        public void AddTransition(IState from, IState to, Func<bool> predicate)
        {
            if(Transitions.TryGetValue(from.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                Transitions[from.GetType()] = transitions;
            }

            transitions.Add(new Transition(to, predicate));
        }

        public void AddInstantTransition(IState state, Func<bool> predicate)
        {
            InstantTransitions.Add(new Transition(state, predicate));
        }

        private Transition GetTransition()
        {
            foreach(var t in InstantTransitions)
            {
                if(t.Condition())
                {
                    return t;
                }
            }

            foreach(var t in CurrentTransitions)
            {
                if(t.Condition())
                {
                    return t;
                }
            }

            return null;
        }

        private class Transition
        {
            public Func<bool> Condition { get; }
            public IState To { get; }

            public Transition(IState to, Func<bool> condition)
            {
                To = to;
                Condition = condition;
            }
        }
    }
}
