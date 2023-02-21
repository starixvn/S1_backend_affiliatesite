namespace AffiliateSite.Link.Domain
{
    public interface IMediaLinkRepository
    {
        Task<AffMediaLink> Load(int affId, string channelCode, string languageCode, string affLink);
        Task Add(AffMediaLink affMediaLink);
        Task Update(AffMediaLink affMediaLink);
        
    }
}
