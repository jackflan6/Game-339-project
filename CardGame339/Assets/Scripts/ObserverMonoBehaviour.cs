﻿using UnityEngine;

namespace Game.Runtime
{
    public abstract class ObserverMonoBehaviour : MonoBehaviour
    {
        
        private bool _didCallStart;
        private bool _didSubscribe;

        protected virtual void Awake()
        {
            _didCallStart = false;
            _didSubscribe = false;
        }

        protected virtual void Start()
        {
            _didCallStart = true;
            TrySubscribe();
        }

        protected virtual void OnEnable()
        {
            TrySubscribe();
        }

        protected virtual void OnDisable()
        {
            TryUnsubscribe();
        }

        private void TrySubscribe()
        {
            if (!_didSubscribe && _didCallStart)
            {
                _didSubscribe = true;
               // Log.Info(GetType().Name + "." + nameof(TrySubscribe));
                Subscribe();
            }
        }

        private void TryUnsubscribe()
        {
            if (_didSubscribe)
            {
                _didSubscribe = false;
              //  Log.Info(GetType().Name + "." + nameof(TryUnsubscribe));
                Unsubscribe();
            }
        }

        protected abstract void Subscribe();

        protected abstract void Unsubscribe();
    }
}