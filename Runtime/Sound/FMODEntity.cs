using System;
#if ENABLE_FMOD
namespace TorkFramework.FMODSound
{
    public class FMODEntity : GameEntity
    {
        public static Action<FMODEntity> Spawn;

        private FMODManager m_FmodManager;
        protected FMODManager FmodManager => m_FmodManager;

        protected override void BeforeAwake()
        {
            Spawn?.Invoke(this);
        }

        public void InitSound(FMODManager manager)
        {
            m_FmodManager = manager;
        }
    }
}
#endif