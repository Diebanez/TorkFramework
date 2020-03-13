using FMODUnity;
using UnityEngine;
#if ENABLE_FMOD
namespace TorkFramework.FMODSound
{
    public class FMODOneShotEmitter : FMODEntity
    {
        [SerializeField, EventRef] private string m_EventPath;

        public void Play()
        {
            FmodManager.PlayOneShot(m_EventPath);
        }
    }
}
#endif