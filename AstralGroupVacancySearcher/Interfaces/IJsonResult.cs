namespace AstralGroupVacancySearcher.Interfaces
{
    internal interface IJsonResult
    {
        bool error { get; set; }
        object data { get; set; }
        object additionalData { get; set; }
    }
}
