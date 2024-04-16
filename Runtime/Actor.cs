using UnityEngine;

namespace PufferSoftware.EventSystem
{
    public abstract class Actor : MonoBehaviour
    {
        #region Properties

        public EventManager Manager => EventManager.Instance;

        #endregion

        #region MonoBehaviour Methods

        protected virtual void OnEnable()
        {
            Listen(true);
        }

        protected virtual void OnDisable()
        {
            Listen(false);
        }

        #endregion

        #region Protected Methods

        protected virtual void Listen(bool status)
        {
        }

        protected virtual void Push(string eventName, params object[] arguments)
        {
            Manager.Push(eventName, arguments);
        }

        protected virtual void Register(string eventName, Event @event)
        {
            Manager.Register(eventName, @event);
        }

        protected virtual void Unregister(string eventName, Event @event)
        {
            Manager.Unregister(eventName, @event);
        }

        #endregion
    }
}