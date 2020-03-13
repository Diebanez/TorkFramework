using System;
using UnityEngine;

namespace TorkFramework
{
    public class GameEntity : MonoBehaviour
    {
        public static Action<GameEntity> Spawn;

        private bool m_InitializedByManager = false;
        private GameEntity m_Prefab;
        private GameManager m_GameManager;

        public GameEntity Prefab => m_Prefab;
        public GameManager GameManager => m_GameManager;

        private void Awake()
        {
            BeforeAwake();
            if (gameObject.GetComponents<GameEntity>().Length > 1)
            {
                DestroyImmediate(this);
                return;
            }

            Spawn?.Invoke(this);
            AfterAwake();
        }

        protected virtual void BeforeAwake()
        {
            
        }

        protected virtual void AfterAwake()
        {
            
        }

        private void Start()
        {
            BeforeStart();
            if(!m_InitializedByManager)
                DestroyImmediate(gameObject);
            AfterStart();
        }

        protected virtual void BeforeStart()
        {
            
        }

        protected virtual void AfterStart()
        {
            
        }
        
        public void InitEntity(GameManager manager)
        {
            m_GameManager = manager;
            m_InitializedByManager = true;
        }

        public void SetPrefab(GameEntity entity)
        {
            m_Prefab = entity;
        }
    }
}