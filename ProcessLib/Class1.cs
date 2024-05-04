namespace ProcessLib
{
    public interface IStampedProcess
    {

    }

    public interface IStamper
    {
        
    }


    public interface IPart
    {
        public Type TypeIn { get; }
        public Type TypeOut { get; }
    }

    public abstract class Part<Tin, Tout> : IPart
    {
        private string lastStamp = string.Empty;
        Tout buffer;
        public Type TypeIn => typeof(Tin);
        public Type TypeOut => typeof(Tout);

        public Tout Process(IStamper stamper, Tin dataIn)
        {
            var thisStamp = GetStamp(stamper, dataIn);
            if(string.IsNullOrEmpty(thisStamp) || thisStamp != lastStamp)
                buffer = DoTheJob(dataIn);
            return buffer;
        }
        public abstract Tout DoTheJob(Tin dataIn);
        public abstract string GetStamp(IStamper stamper, Tin tinObj);
    }


    public class Process
    {

    }
}
