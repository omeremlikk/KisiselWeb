using System.Text.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KisiselBlog.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ShortDescription { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string GifUrl { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public bool IsFeatured { get; set; }
    
    // JSON verileri için string alanlar
    public string? FeaturesJson { get; set; }
    public string? TechnologiesJson { get; set; }
    
    // Model tarafında kullanılacak listeler
    [NotMapped]
    public List<string> Features { 
        get => string.IsNullOrEmpty(FeaturesJson) 
            ? new List<string>() 
            : JsonSerializer.Deserialize<List<string>>(FeaturesJson) ?? new List<string>();
        set => FeaturesJson = JsonSerializer.Serialize(value);
    }
    
    [NotMapped]
    public List<string> Technologies { 
        get => string.IsNullOrEmpty(TechnologiesJson) 
            ? new List<string>() 
            : JsonSerializer.Deserialize<List<string>>(TechnologiesJson) ?? new List<string>();
        set => TechnologiesJson = JsonSerializer.Serialize(value);
    }
} 