using JsonFormatting = Newtonsoft.Json.Formatting;
using XmlFormatting = System.Xml.Formatting;
using System.Collections.Generic;
using System.Linq;
using ImageManagementAPI.Models;
using Newtonsoft.Json;
using System.IO;
using System.Xml;

namespace ImageManagementAPI.Data
{
    public class ImageRepository
    {
        private const string FilePath = "Data/images.json";
        private List<Image> _images;

        public ImageRepository()
        {
            if (File.Exists(FilePath))
            {
                var jsonData = File.ReadAllText(FilePath);
                _images = JsonConvert.DeserializeObject<List<Image>>(jsonData) ?? new List<Image>();
            }
            else
            {
                _images = new List<Image>();
            }
        }

        public IEnumerable<Image> GetAllImages() => _images;

        public Image GetImageById(int id) => _images.FirstOrDefault(i => i.Id == id);

        public void CreateImage(Image image)
        {
            image.Id = _images.Any() ? _images.Max(i => i.Id) + 1 : 1;
            _images.Add(image);
            SaveChanges();
        }

        public void UpdateImage(Image image)
        {
            var index = _images.FindIndex(i => i.Id == image.Id);
            if (index >= 0)
            {
                _images[index] = image;
                SaveChanges();
            }
        }

        public void DeleteImage(int id)
        {
            var image = _images.FirstOrDefault(i => i.Id == id);
            if (image != null)
            {
                _images.Remove(image);
                SaveChanges();
            }
        }

        private void SaveChanges()
        {
            var jsonData = JsonConvert.SerializeObject(_images, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, jsonData);
        }
    }
}
