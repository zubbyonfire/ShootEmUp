using UnityEngine;
using System.Collections;

namespace R42.GameEvents
{
    [CreateAssetMenu(fileName = "New Vector3 Event", menuName = "Events/Vector3 Event")]
    [System.Serializable]
    public class Vector3Event : BaseGameEvent<Vector3> { }
}
