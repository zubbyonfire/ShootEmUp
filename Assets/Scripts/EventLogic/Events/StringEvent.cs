using UnityEngine;
using System.Collections;

namespace R42.GameEvents
{
    [CreateAssetMenu(fileName = "New String Event", menuName = "Events/String Event")]
    [System.Serializable]
    public class StringEvent : BaseGameEvent<string> { }
}
