using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PufferSoftware.EventSystem
{
    [DefaultExecutionOrder(-1001)]
    public class EventManager : MonoBehaviour
    {
        #region Public Variables

        public static EventManager Instance;

        #endregion

        #region Private Variables

        private Dictionary<string, List<Event>> _events = new();

        #endregion

        #region MonoBehaviour Methods

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }

            else
            {
                Destroy(gameObject);
            }

            hideFlags = HideFlags.HideInHierarchy;
        }

        #endregion

        #region Public Methods

        public void Push(string eventName, params object[] arguments)
        {
            if (!_events.ContainsKey(eventName))
            {
                return;
            }

            List<KeyValuePair<string, List<Event>>> events = _events.Where(x => x.Key == eventName).ToList();

            foreach (Event roaring in events.Select(myEvent => myEvent.Value.ToList())
                         .SelectMany(eventList => eventList))
            {
                roaring?.Invoke(arguments);
            }
        }

        public void Register(string eventName, Event @event)
        {
            List<Event> events;

            if (!_events.ContainsKey(eventName))
            {
                events = new List<Event> { @event };
                _events.Add(eventName, events);
            }

            else
            {
                events = _events[eventName];
                events.Add(@event);
            }
        }

        public void Unregister(string roarName, Event @event)
        {
            List<Event> events = _events[roarName];

            if (events.Count > 0)
            {
                events.Remove(@event);
            }
            
            if (events.Count == 0)
            {
                _events.Remove(roarName);
            }
        }

        #endregion
    }
}