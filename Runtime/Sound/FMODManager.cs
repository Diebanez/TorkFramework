using System;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
#if ENABLE_FMOD
namespace TorkFramework.FMODSound
{
    public class FMODManager : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
            FMODEntity.Spawn += OnEntitySpawn;
            m_SpawnedInstances = new Dictionary<int, EventInstance>();
        }

        private Dictionary<int, EventInstance> m_SpawnedInstances;
        private int m_ActualSpawnID = 0;

        private void OnEntitySpawn(FMODEntity component)
        {
            component.InitSound(this);
        }

        public void PlayOneShot(string eventPath)
        {
            RuntimeManager.PlayOneShot(eventPath);
        }

        public int SpawnEvent(string eventPath)
        {
            try
            {
                var id = m_ActualSpawnID;
                m_ActualSpawnID++;
                if (string.IsNullOrEmpty(eventPath))
                    throw new NullReferenceException("No Event Path Found");

                m_SpawnedInstances.Add(id, RuntimeManager.CreateInstance(eventPath));
                return id;
            }
            catch (Exception ex)
            {
                throw new NullReferenceException("No Event Path Found");
            }
        }

        public void PlayEvent(int eventID, params FMODParameter[] parameters)
        {
            m_SpawnedInstances[eventID].start();
            foreach (var parameter in parameters)
            {
                m_SpawnedInstances[eventID].setParameterByName(parameter.ParameterName, parameter.ParameterValue);
            }
        }

        public void PauseEvent(int eventID)
        {
            m_SpawnedInstances[eventID].setPaused(true);
        }

        public void ResumeEvent(int eventID)
        {
            m_SpawnedInstances[eventID].setPaused(false);
        }

        public void StopEvent(int eventID, FMOD.Studio.STOP_MODE mode)
        {
            m_SpawnedInstances[eventID].stop(mode);
        }

        public void TriggerEventCue(int eventID)
        {
            m_SpawnedInstances[eventID].triggerCue();
        }

        public void BindEvent(int eventID, Transform targetTransform, Rigidbody targetBody = null)
        {
            RuntimeManager.AttachInstanceToGameObject(m_SpawnedInstances[eventID], targetTransform, targetBody);
            m_SpawnedInstances[eventID].set3DAttributes(RuntimeUtils.To3DAttributes(targetTransform));
        }

        public void BindEvent(int eventID, Transform targetTransform, Rigidbody2D targetBody = null)
        {
            RuntimeManager.AttachInstanceToGameObject(m_SpawnedInstances[eventID], targetTransform, targetBody);
            m_SpawnedInstances[eventID].set3DAttributes(RuntimeUtils.To3DAttributes(targetTransform));
        }

        public void ReleaseEvent(int eventID)
        {
            m_SpawnedInstances[eventID].release();
        }
    }
}
#endif