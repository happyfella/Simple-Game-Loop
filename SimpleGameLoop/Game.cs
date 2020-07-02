using SimpleGameLoop.Infrastructure.StateMachines;
using SimpleGameLoop.Infrastructure.StateMachines.States.GameFlow;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleGameLoop
{
    public class Game
    {
        private bool isRunning = true;
        private GeneralStateMachine gameFlowMachine;

        public Game()
        {
            gameFlowMachine = new GeneralStateMachine();            
        }

        public void Run()
        {
            // Define the states for the game flow machine.
            var splashState = new SplashState(this);
            var gameState = new GameState(this);
            var mainMenuState = new MainMenuState(this);

            // Define delegates for state conditions.
            Func<bool> SplashScreenComplete() => () => splashState.ExitState;
            Func<bool> GameComplete() => () => gameState.ExitState;
            Func<bool> OnNewGame() => () => mainMenuState.NewGameSelected;

            // Assigne transisitons for game flow machine
            gameFlowMachine.AddTransition(splashState, mainMenuState, SplashScreenComplete());
            gameFlowMachine.AddTransition(mainMenuState, gameState, OnNewGame());
            gameFlowMachine.AddTransition(gameState, mainMenuState, GameComplete());

            // Set the initial state the game will start with.
            gameFlowMachine.SetState(splashState);

            while (isRunning)
            {
                gameFlowMachine.Tick();
            }
        }
    }
}
