using AffiliateSite.Framework;
using AffiliateSite.Link.Messages.MediaLink;

namespace AffiliateSite.Link.Domain
{
    public class AffMediaLink : AggregateRoot<AffMediaLinkId>
    {
        public AffId AffId { get; private set; }
        public string ChannelCode { get; private set; }
        public string LanguageCode { get; private set; }
        public string AffLink { get; private set; }
        public MediaLinkStatus Status { get; set; }
        public AffMediaLink() { }
        public AffMediaLink(AffId affId, string channelCode, string languageCode, string affLink) =>
            Apply(new Events.CreateMarketingLink
            {
                AffId = affId,
                ChannelCode = channelCode,
                LanguageCode = languageCode,
                AffLink = affLink
            });

        public void ToggleStatus(MediaLinkStatus status) =>
            Apply(new Events.ToggleStatus
            {
                Status = (int)status
            });
        protected override void When(object @event)
        {
            switch (@event)
            {
                case Events.CreateMarketingLink e:
                    AffId = new AffId(e.AffId);
                    ChannelCode = e.ChannelCode;
                    LanguageCode = e.LanguageCode;
                    AffLink = e.AffLink;
                    Status = MediaLinkStatus.On;
                    break;
                case Events.ToggleStatus e:
                    Status = (MediaLinkStatus)e.Status;
                    break;
            }
        }
    }

    public enum MediaLinkStatus
    {
        Off,
        On
    }
}
