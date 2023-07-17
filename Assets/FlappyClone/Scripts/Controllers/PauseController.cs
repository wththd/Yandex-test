using System.Collections.Generic;

namespace FlappyClone.Scripts.Controllers
{
    public static class PauseController
    {
        private static List<IPausable> pausables = new List<IPausable>();

        public static void RegisterPausable(IPausable pausable)
        {
            pausables.Add(pausable);
        }

        public static void UnregisterPausable(IPausable pausable)
        {
            pausables.Remove(pausable);
        }

        public static void Pause()
        {
            foreach (var pausable in pausables)
            {
                pausable.Pause();
            }
        }
        
        public static void Resume()
        {
            foreach (var pausable in pausables)
            {
                pausable.Resume();
            }
        }
    }
}