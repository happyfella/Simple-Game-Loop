using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SimpleGameLoop.Utils
{
    public class GameTime
    {
        public GameTime() { }

        public float DeltaTime { get; set; }

        public float TotalTimeElapsed { get; set; }

        public void Update(float deltaTime, float totalTimeElapsed)
        {
            DeltaTime = deltaTime;
            TotalTimeElapsed = totalTimeElapsed;
        }
    }
}
