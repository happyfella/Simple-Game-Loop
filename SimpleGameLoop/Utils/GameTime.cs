using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleGameLoop.Utils
{
    public class GameTime
    {
        public GameTime()
        {
            Clock = new Stopwatch();
            Clock.Start();
        }

        public Stopwatch Clock { get; set; } // Use Clock from SFML.System if using SFML

        public float DeltaTime { get; set; }

        public float TotalTimeElapsed { get; set; }

        public void Update(float deltaTime, float totalTimeElapsed)
        {
            DeltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}
