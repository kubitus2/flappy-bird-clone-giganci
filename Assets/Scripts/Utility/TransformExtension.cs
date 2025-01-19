using UnityEngine;

namespace Utility
{
    public static class TransformExtension
    {
        public static void KillAllObstacles(this Transform t)
        {
            var obstacles = t.GetComponentsInChildren<Obstacle>();
            foreach (var obstacle in obstacles)
            {
                obstacle.Kill();
            }
        }
    }
}