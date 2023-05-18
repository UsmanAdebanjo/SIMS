namespace SIMS.Services
{
    public interface IThirdPartyService
    {
        public  Task<string> GetApiData(string apiUrl);
    }
}
