using FMODUnity;
using UnityEngine;
#if ENABLE_FMOD
namespace TorkFramework.FMODSound
{
    public class FMODEventEmitter : FMODEntity
    {
        [Header("Event Settings")] 
        [SerializeField, EventRef] private string m_EventPath;
        [SerializeField] private FMODParameter[] m_Parameters;

        [Header("Binding Settings")] 
        [SerializeField] private bool m_BindToObject;
        [SerializeField] private Transform m_TargetTransform;
        [SerializeField] private Rigidbody m_TargetBody;
        [SerializeField] private Rigidbody2D m_TargetBody2D;

        private int m_EventID = -1;

        private void OnEnable()
        {
            if (FmodManager != null)
            {
                m_EventID = FmodManager.SpawnEvent(m_EventPath);
            }
        }

        private void OnDisable()
        {
            FmodManager.ReleaseEvent(m_EventID);
            m_EventID = -1;
        }

        public void Play()
        {
            if (m_EventID >= 0)
            {
                if (m_BindToObject)
                {
                    if (m_TargetBody == null)
                        FmodManager.BindEvent(m_EventID, m_TargetTransform, m_TargetBody2D);
                    else
                        FmodManager.BindEvent(m_EventID, m_TargetTransform, m_TargetBody);
                }
                FmodManager.PlayEvent(m_EventID, m_Parameters);
            }
        }

        public void Pause()
        {
            if (m_EventID >= 0)
            {
                FmodManager.PauseEvent(m_EventID);
            }
        }

        public void Resume()
        {
            if (m_EventID >= 0)
            {
                FmodManager.ResumeEvent(m_EventID);
            }
        }

        public void Stop()
        {
            if (m_EventID >= 0)
            {
                FmodManager.StopEvent(m_EventID, FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            }
        }

        public void TriggerCue()
        {
            if (m_EventID >= 0)
            {
                FmodManager.TriggerEventCue(m_EventID);
            }
        }
    }
}
#endif