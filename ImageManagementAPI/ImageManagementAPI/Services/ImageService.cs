using System.Collections.Generic;
using ImageManagementAPI.Data;
using ImageManagementAPI.Models;

namespace ImageManagementAPI.Services
{
    public interface IImageService
    {
        IEnumerable<Image> GetAllImages();
        Image GetImageById(int id);
        void CreateImage(Image image);
        void UpdateImage(Image image);
        void DeleteImage(int id);
    }

    public class ImageService : IImageService
    {
        private readonly ImageRepository _repository;

        public ImageService()
        {
            _repository = new ImageRepository();
        }

        public IEnumerable<Image> GetAllImages() => _repository.GetAllImages();

        public Image GetImageById(int id) => _repository.GetImageById(id);

        public void CreateImage(Image image) => _repository.CreateImage(image);

        public void UpdateImage(Image image) => _repository.UpdateImage(image);

        public void DeleteImage(int id) => _repository.DeleteImage(id);
    }
}
