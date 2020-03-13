using UnityEngine;

namespace TorkFramework
{
    [RequireComponent(typeof(GameEntity))]
    public class EntityBehaviour : MonoBehaviour
    {
        private GameEntity m_Entity;

        public GameEntity Entity
        {
            get
            {
                if (m_Entity == null)
                    m_Entity = GetComponent<GameEntity>();
                return m_Entity;
            }
        }
    }
}