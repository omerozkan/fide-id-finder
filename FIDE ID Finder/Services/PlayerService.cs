using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIDE_ID_Finder.Model;

namespace FIDE_ID_Finder.Services
{
    public class PlayerService
    {
        private readonly RatingFileDownloader _fileDownloader = new RatingFileDownloader();

        public event EventHandler<ProgressStatus>? ProgressStatusChanged;

        public PlayerService()
        {
            _fileDownloader.ProgressStatusChanged += (sender, status) =>
            {
                ProgressStatusChanged?.Invoke(this, status);
            };
        }

        public async Task<IList<Player>> FindPlayers(RatingType type, IList<Player> players)
        {
            var found = await _fileDownloader.FindPlayers(type,players);
            return found;
        }

        public async Task ReDownloadRatingFile(RatingType type)
        {
            await _fileDownloader.ReDownloadFile(type);
        }
    }
}
