using UnityEngine;

namespace PufferSoftware.EventSystem
{
    public class Listener : Actor
    {
        protected override void Listen(bool status)
        {
            if (status)
            {
                Register(CustomEvents.EventTest, Test);
            }

            else
            {
                Unregister(CustomEvents.EventTest, Test);
            }
        }

        private void Test(object[] arguments)
        {
            Debug.Log("Test " + (int)arguments[0]);
        }
    }
}