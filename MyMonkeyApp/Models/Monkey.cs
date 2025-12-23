namespace MyMonkeyApp.Models;

/// <summary>
/// Represents a monkey species with its characteristics and attributes.
/// </summary>
public class Monkey
{
    /// <summary>
    /// Gets or sets the unique identifier for the monkey species.
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Gets or sets the common name of the monkey species.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the scientific name of the monkey species.
    /// </summary>
    public string? ScientificName { get; set; }

    /// <summary>
    /// Gets or sets the geographic region where the monkey is found.
    /// </summary>
    public string? Region { get; set; }

    /// <summary>
    /// Gets or sets the habitat type where the monkey lives.
    /// </summary>
    public string? Habitat { get; set; }

    /// <summary>
    /// Gets or sets the typical lifespan of the monkey in years.
    /// </summary>
    public int? Lifespan { get; set; }

    /// <summary>
    /// Gets or sets the average weight of the monkey in kilograms.
    /// </summary>
    public double? Weight { get; set; }

    /// <summary>
    /// Gets or sets the average height of the monkey in centimeters.
    /// </summary>
    public double? Height { get; set; }

    /// <summary>
    /// Gets or sets the diet description of the monkey.
    /// </summary>
    public string? Diet { get; set; }

    /// <summary>
    /// Gets or sets a detailed description of the monkey species.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the conservation status of the monkey species.
    /// </summary>
    public string? ConservationStatus { get; set; }

    /// <summary>
    /// Gets or sets the population trend of the monkey species.
    /// </summary>
    public string? PopulationTrend { get; set; }

    /// <summary>
    /// Gets or sets the image URL for the monkey species.
    /// </summary>
    public string? ImageUrl { get; set; }

    /// <summary>
    /// Gets or sets the social structure of the monkey species.
    /// </summary>
    public string? SocialStructure { get; set; }

    /// <summary>
    /// Gets or sets the intelligence level of the monkey species.
    /// </summary>
    public string? IntelligenceLevel { get; set; }
}
