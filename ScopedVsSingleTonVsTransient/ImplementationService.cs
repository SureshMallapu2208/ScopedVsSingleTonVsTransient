namespace ScopedVsSingleTonVsTransient
{
    public class ImplementationService : ISingleTon, IScoped, ITransient
    {
        Guid id;
        public ImplementationService()
        {
            id = Guid.NewGuid();
        }

        public Guid GetOperationID()
        {
            return id;
        }
    }
}
