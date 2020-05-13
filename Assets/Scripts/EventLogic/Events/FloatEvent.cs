using UnityEngine;
using System.Collections;

namespace R42.GameEvents
{
    [CreateAssetMenu(fileName = "New Float Event", menuName = "Events/Float Event")]
    [System.Serializable]
    public class FloatEvent : BaseGameEvent<float> { }
}
