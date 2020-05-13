using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace R42.GameEvents
{
    public interface IGameEventListener<T>
    {
        void OnEventRaised(T item);
    }
}