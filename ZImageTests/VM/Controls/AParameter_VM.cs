using ZImageTests.VM.Basic;

namespace ZImageTests.VM.Controls
{
    public abstract class AParameter_VM : ObservableObject
    {
        public string ParamType => this.GetType().Name;
    }
}
