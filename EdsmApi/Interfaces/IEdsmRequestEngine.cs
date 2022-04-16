namespace EdsmApi.Interface
{
    public interface IEdsmRequestEngine
    {
        TModels Get<TModels>(IEdsmQuery<TModels> query) where TModels : new();
    }
}
