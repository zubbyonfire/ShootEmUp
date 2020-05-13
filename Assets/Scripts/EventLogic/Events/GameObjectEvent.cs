using UnityEngine;
using System.Collections;

namespace R42.GameEvents
{
    [CreateAssetMenu(fileName = "New GameObject Event", menuName = "Events/GameObject Event")]
    [System.Serializable]
    public class GameObjectEvent : BaseGameEvent<GameObject> { }
}
