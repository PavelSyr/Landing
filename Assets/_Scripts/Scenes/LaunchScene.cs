using Launch;

namespace Scenes
{
    public class LaunchScene : BaseScene
    {
        protected override void Initialisation()
        {
            base.Initialisation();

            context = new LaunchContext(this);
        }
    }
}
