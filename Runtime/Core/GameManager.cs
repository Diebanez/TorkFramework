using UnityEngine;
#if ENABLE_FMOD
using TorkFramework.FMODSound;
#endif

namespace TorkFramework{
    public abstract class GameManager : MonoBehaviour
    {
#if ENABLE_FMOD
        [SerializeField] private FMODManager m_SoundManagerPrefab;
        private FMODManager m_SoundManager;
#endif

        private void Awake()
        {
            DontDestroyOnLoad(this);
            GameEntity.Spawn += OnEntitySpawn;
#if ENABLE_FMOD
            m_SoundManager = Instantiate(m_SoundManagerPrefab);
#endif
        }
        
        protected virtual void AfterAwake(){}

        private void OnEntitySpawn(GameEntity entity)
        {
            entity.InitEntity(this);
        }

        public GameEntity Spawn(GameEntity entity)
        {
            var newEntity = Instantiate(entity);
            newEntity.SetPrefab(entity);
            return newEntity;
        }

        public T Spawn<T>(T behaviour) where T : EntityBehaviour
        {
            var newEntity = Spawn(behaviour.Entity);
            return newEntity.GetComponent<T>();
        }

        public void Kill(GameEntity entity)
        {
            Destroy(entity.gameObject);
        }
    }
}