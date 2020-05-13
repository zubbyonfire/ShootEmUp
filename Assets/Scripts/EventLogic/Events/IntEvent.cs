using UnityEngine;
using System.Collections;

namespace R42.GameEvents
{
    [CreateAssetMenu(fileName ="New Int Event", menuName ="Events/Int Event")]
    [System.Serializable]
    public class IntEvent : BaseGameEvent<int> { }
}
