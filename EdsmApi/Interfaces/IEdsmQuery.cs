namespace EdsmApi.Interface
{
    public interface IEdsmQuery
    {
        public string Url { get; }
    }

    public interface IEdsmQuery<TModels> : IEdsmQuery
    {
    }
}
