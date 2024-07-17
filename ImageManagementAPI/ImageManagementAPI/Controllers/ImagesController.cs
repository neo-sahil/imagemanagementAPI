using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ImageManagementAPI.Models;
using ImageManagementAPI.Services;

[Route("api/[controller]")]
[ApiController]
public class ImagesController : ControllerBase
{
    private readonly IImageService _imageService;

    public ImagesController(IImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Image>> GetImages()
    {
        return Ok(_imageService.GetAllImages());
    }

    [HttpGet("{id}")]
    public ActionResult<Image> GetImage(int id)
    {
        var image = _imageService.GetImageById(id);
        if (image == null) return NotFound();
        return Ok(image);
    }

    [HttpPost]
    public ActionResult CreateImage(Image image)
    {
        _imageService.CreateImage(image);
        return CreatedAtAction(nameof(GetImage), new { id = image.Id }, image);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateImage(int id, Image image)
    {
        if (id != image.Id) return BadRequest();
        var existingImage = _imageService.GetImageById(id);
        if (existingImage == null) return NotFound();
        _imageService.UpdateImage(image);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteImage(int id)
    {
        var image = _imageService.GetImageById(id);
        if (image == null) return NotFound();
        _imageService.DeleteImage(id);
        return NoContent();
    }
}
