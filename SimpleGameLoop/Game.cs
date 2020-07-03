using SimpleGameLoop.Infrastructure.StateMachines;
using SimpleGameLoop.Infrastructure.StateMachines.States.GameFlow;
using SimpleGameLoop.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SimpleGameLoop
{
    public class Game
    {
        private const float MS_PER_UPDATE = 16f;
        private bool isRunning = true;
        private GeneralStateMachine gameFlowMachine;
        private GameTime gameTime;

        public Game()
        {
            gameFlowMachine = new GeneralStateMachine();
            gameTime = new GameTime();
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

            // Setup game time
            var totalTimeElapsed = 0f;
            var previousTimeElapsed = 0f;
            var deltaTime = 0f;
            var lag = 0f;

            while (isRunning)
            {
                // Game time calculations
                totalTimeElapsed = gameTime.Clock.ElapsedMilliseconds;
                deltaTime = totalTimeElapsed - previousTimeElapsed;
                previousTimeElapsed = totalTimeElapsed;
                lag += deltaTime;

                // Process gameFlowMachine Process method to handle user input

                while(lag >= MS_PER_UPDATE)
                {
                    // Process gameFlowMachine Update method to perform game calculations and object updates
                    gameTime.Update(lag, totalTimeElapsed);

                    lag -= MS_PER_UPDATE;
                }

                // Process gameFlowMachine Render method to draw to the screen... Render(lag / MS_PER_UPDATE)
                gameFlowMachine.Tick();
            }
        }
    }
}
