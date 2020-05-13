using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace R42.GameEvents
{
    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, IGameEventListener<T> where E:
        BaseGameEvent<T> where UER: UnityEvent<T>
    {
        [SerializeField] private E gameEvent;
        public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

        public UER unityEventResponse;

        private void OnEnable()
        {
            if (gameEvent == null) { return; }

            //Debug.Log("Register listener " + this.gameObject.name);

            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null) { return; }

            //Debug.Log("Unregister listener " + this.gameObject.name);

            gameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item)
        {
            if (unityEventResponse != null)
            {
                unityEventResponse.Invoke(item);
            }
        }
    }
}
