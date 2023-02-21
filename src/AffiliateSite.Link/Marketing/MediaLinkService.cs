using AffiliateSite.Link.Domain;
using AffiliateSite.Link.Messages.MediaLink;

namespace AffiliateSite.Link.Marketing
{
    public class MediaLinkService
    {
        private readonly IMediaLinkRepository _repository;

        public MediaLinkService(IMediaLinkRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(object command, int affId)
        {
            switch (command)
            {
                case Commands.ToggleMarketingLink cmd:
                    var mediaLink = await _repository.Load(affId, cmd.ChannelCode, cmd.LanguageCode, cmd.AffLink);

                    if (mediaLink == null)
                    {
                        mediaLink = new AffMediaLink(affId, cmd.ChannelCode, cmd.LanguageCode, cmd.AffLink);
                        await _repository.Add(mediaLink);
                    }
                    else
                    {
                        mediaLink.ToggleStatus((MediaLinkStatus)cmd.IsOn);
                        await _repository.Update(mediaLink);
                    }
                    break;
            }
        }
    }
}
