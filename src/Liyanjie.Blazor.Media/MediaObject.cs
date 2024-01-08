namespace Liyanjie.Blazor.Media;

public record MediaObject
{
    public bool Autoplay { get; init; }
    public bool Controls { get; init; }
    public string? CrossOrigin { get; init; }
    public double CurrentTime { get; init; }
    public double Duration { get; init; }
    public bool Loop { get; init; }
    public bool Muted { get; init; }
    public string? Preload { get; init; }
    public double Volume { get; init; }
}
