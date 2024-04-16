
namespace PufferSoftware.EventSystem
{
    public class Sender : Actor
    {
        private void Start()
        {
            Push(CustomEvents.EventTest, 123);
        }
    }
}