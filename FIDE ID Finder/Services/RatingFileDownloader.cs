using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using FIDE_ID_Finder.Model;

namespace FIDE_ID_Finder.Services
{
    //TODO delete unnecessary files
    public class RatingFileDownloader
    {
        private const string StandardFileUrl = "http://ratings.fide.com/download/standard_rating_list_xml.zip";
        private const string RapidFileUrl = "http://ratings.fide.com/download/rapid_rating_list_xml.zip";
        private const string BlitzFileUrl = "http://ratings.fide.com/download/blitz_rating_list_xml.zip";

        private readonly string _rootPath;
        private readonly string _tmpPath;

        private const string StandardXmlFilePath = "downloaded\\standard_rating_list.xml";
        private const string RapidXmlFilePath = "downloaded\\rapid_rating_list.xml";
        private const string BlitzXmlFilePath = "downloaded\\blitz_rating_list.xml";

        private const string StandardSourceDirectory = "data-std";
        private const string RapidSourceDirectory = "data-blitz";
        private const string BlitzSourceDirectory = "data-rapid";

        private readonly LogService _logService = LogService.Get();
        public event EventHandler<ProgressStatus>? ProgressStatusChanged;

        public RatingFileDownloader()
        {
            string rootPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData,
                Environment.SpecialFolderOption.Create);
            _rootPath = rootPath + "\\FideIDFinder";

            string tmpPath = Path.GetTempPath();
            _tmpPath = tmpPath + "\\FideIDFinder";

            if (!Directory.Exists(_tmpPath))
            {
                Directory.CreateDirectory(_tmpPath);
            }
        }

        private async Task DownloadFile(RatingType ratingType)
        {
            using var client = new HttpClient();
            var fideFileUrl = GetFideFileUrl(ratingType);
            _logService.Log("Downloading file from " + fideFileUrl);

            var s = await client.GetStreamAsync(new Uri(fideFileUrl));

            if (!Directory.Exists(_tmpPath + "\\downloaded"))
            {
                Directory.CreateDirectory(_tmpPath + "\\downloaded");
            }

            var zipFile = _tmpPath + "\\downloaded\\" + GetZipFileNameFor(ratingType);

            var file = new FileStream(zipFile, FileMode.OpenOrCreate);
            if (file.CanWrite)
            {
                await s.CopyToAsync(file);

            }
            _logService.Log("File downloaded " + fideFileUrl);

            file.Close();
            s.Close();
            
            UnzipFile(zipFile);
        }

        private void UnzipFile(string path)
        {
            _logService.Log("Extracting rating file from zip directory");
            ZipFile.ExtractToDirectory(path, _tmpPath + "\\downloaded");
            _logService.Log("Zip file has been extracted");
        }

        private async Task InitFile(RatingType type)
        {
            var sourcePath = GetSourceDirectory(type);
            if (Directory.Exists(sourcePath))
            {
                _logService.Log("Players' file already been converted. Skipping downloading");
                return;
            }
            var xmlFilePath = GetXmlFilePath(type);

            if (!File.Exists(xmlFilePath))
            {
              _logService.Log(xmlFilePath + " does not exist. Needs to be downloaded");

                ProgressStatusChanged?.Invoke(this, ProgressStatus.Downloading);
                await DownloadFile(type);
            }

            if (!Directory.Exists(sourcePath))
            {
                _logService.Log("Converting XML to JSON files");
                ProgressStatusChanged?.Invoke(this, ProgressStatus.ConvertingFiles);
                await ConvertToJsonFile(sourceDirectory: sourcePath, xmlFilePath: xmlFilePath);
            }

            var zipFile = _tmpPath + "\\downloaded\\" + GetZipFileNameFor(type);
            if (File.Exists(zipFile))
            {
                File.Delete(zipFile);
                _logService.Log(zipFile + " has been deleted");
            }
        }

        public async Task ReDownloadFile(RatingType type)
        {
            ProgressStatusChanged?.Invoke(this, ProgressStatus.DeletingOldFiles);
            _logService.Log("ReDownloading and converting rating files for " + type);
            var xmlFilePath = GetXmlFilePath(type);
            if (File.Exists(xmlFilePath))
            {
                File.Delete(xmlFilePath);
            }

            var sourcePath = GetSourceDirectory(type);
            if (Directory.Exists(sourcePath))
            {
                Directory.Delete(sourcePath, true);
            }

            if (File.Exists(_tmpPath + "\\downloaded\\" + GetZipFileNameFor(type)))
            {
                File.Delete(_tmpPath + "\\downloaded\\" + GetZipFileNameFor(type));
            }

            await InitFile(type);
            ProgressStatusChanged?.Invoke(this, ProgressStatus.Finished);
        }

        public async Task<IList<Player>> FindPlayers(RatingType type, IList<Player> playersToFind)
        {
            _logService.Log("Searching players for rating type " + type + " for " + playersToFind.Count + " players.");

            await InitFile(type);
            ProgressStatusChanged?.Invoke(this, ProgressStatus.Searching);
            var result = new List<Player>();

            var keyPlayersPair = playersToFind.GroupBy(x => x.Surname[0].ToString())
                .ToDictionary(p => p.Key, p => p);

            var sourceDir = GetSourceDirectory(type);

            foreach (var key in keyPlayersPair.Keys)
            {
                var reader = new StreamReader(sourceDir + "\\" + key + ".json");
                var players = keyPlayersPair[key];
                while (await reader.ReadLineAsync() is { } line)
                {
                    foreach (var player in players)
                    {
                        if (line.Contains(
                                $"\"Name\":\"{player.Name}\",\"Surname\":\"{player.Surname}\""))
                        {
                            if (player.Birthday.Length == 0 || line.Contains($"\"Birthday\":\"{player.Birthday}\""))
                            {
                                var found = JsonSerializer.Deserialize<Player>(line);
                                result.Add(found);
                            }
                        }
                    }
                }
                reader.Close();
            }
            ProgressStatusChanged?.Invoke(this, ProgressStatus.Finished);
            _logService.Log(result.Count + " players have been found ");

            return result;
        }

        private async Task ConvertToJsonFile(string sourceDirectory, string xmlFilePath)
        {
            _logService.Log("Converting xml file to json files");
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
                _logService.Log("Directory " + sourceDirectory + " has been created");
            }

            using var fs = new StreamReader(xmlFilePath);

            var settings = new XmlReaderSettings
            {
                Async = true
            };

            using var reader = XmlReader.Create(fs, settings);

            string? currentKey = null;

            StreamWriter? writer = null;
            while (await reader.ReadAsync())
            {
                if (reader is not { NodeType: XmlNodeType.Element, Name: "player" }) continue;

                var player = ConvertToPlayer(reader);

                var playerIndex = player.Surname[0].ToString().ToUpper();

                if (currentKey == null || !playerIndex.Equals(currentKey) )
                {
                    _logService.Log("Converting players who has name starts with " + playerIndex + " completed!");
                    currentKey = playerIndex;
                    writer?.Close();

                    var output = new FileStream(sourceDirectory + "\\" + currentKey + ".json",
                        FileMode.OpenOrCreate);
                    writer = new StreamWriter(output);
                }

                var json = JsonSerializer.Serialize(player);
                await writer!.WriteLineAsync(json);
            }

            reader.Close();
            writer?.Close();
            fs.Close();
            _logService.Log("Converting players has finished");

        }

        private static Player ConvertToPlayer(XmlReader reader)
        {
            var player = new Player();

            if (reader.ReadToFollowing("fideid"))
            {
                player.Id = (string)reader.ReadElementContentAsObject();
            }

            if (reader.ReadToFollowing("name"))
            {
                player.Fullname = (string)reader.ReadElementContentAsObject();
            }

            if (reader.ReadToFollowing("country"))
            {
                player.Fed = (string)reader.ReadElementContentAsObject();
            }

            if (reader.ReadToFollowing("title"))
            {
                player.Title = (string)reader.ReadElementContentAsObject();
            }

            if (reader.ReadToFollowing("rating"))
            {
                player.Rating = (string)reader.ReadElementContentAsObject();
            }

            if (reader.ReadToFollowing("birthday"))
            {
                player.Birthday = (string)reader.ReadElementContentAsObject();
            }

            return player;
        }

        private string GetZipFileNameFor(RatingType type)
        {
            return type switch
            {
                RatingType.Blitz => "blitz.zip",
                RatingType.Rapid => "rapid.zip",
                _ => "standard.zip"
            };
        }

        private string GetXmlFilePath(RatingType type)
        {
            return _tmpPath + "\\" + type switch
            {
                RatingType.Blitz => BlitzXmlFilePath,
                RatingType.Rapid => RapidXmlFilePath,
                _ => StandardXmlFilePath
            };
        }

        private string GetSourceDirectory(RatingType type)
        {
            return _rootPath + "\\" + type switch
            {
                RatingType.Blitz => BlitzSourceDirectory,
                RatingType.Rapid => RapidSourceDirectory,
                _ => StandardSourceDirectory
            };
        }

        private string GetFideFileUrl(RatingType type)
        {
            return type switch
            {
                RatingType.Blitz => BlitzFileUrl,
                RatingType.Rapid => RapidFileUrl,
                _ => StandardFileUrl
            };
        }
    }
}
