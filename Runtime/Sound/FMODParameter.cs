using System;
using UnityEngine;
#if ENABLE_FMOD
namespace TorkFramework.FMODSound
{
    [Serializable]
    public class FMODParameter
    {
        [SerializeField] private string m_ParameterName;
        [SerializeField] private float m_ParameterValue;

        public string ParameterName => m_ParameterName;

        public float ParameterValue
        {
            get => m_ParameterValue;
            set => m_ParameterValue = value;
        }

        public FMODParameter(string parameterName, float parameterValue = 0)
        {
            m_ParameterName = parameterName;
            m_ParameterValue = parameterValue;
        }
    }
}
#endif