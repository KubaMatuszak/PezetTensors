using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZImageTests.VM.Reactive
{
    public static class UglyMess
    {
        public static Publisher MinimizePublisher = new Publisher();
        public static Publisher MaximizePublisher = new Publisher();
        public static Publisher UnMaximizePublisher = new Publisher();
        public static Publisher<string> ClosePublisher = new Publisher<string>();

        public static Main_VM Main_VM { get; set; } = new Main_VM();
    }
}
