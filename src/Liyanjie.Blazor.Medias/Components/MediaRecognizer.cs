using Microsoft.AspNetCore.Components;

namespace Liyanjie.Blazor.Medias.Components;

public class MediaRecognizer : ComponentBase
{
    [Inject] JsInterop? JsInterop { get; set; }
    [Parameter] public string? MediaId { get; set; }

    public ValueTask<MediaObject>? Get() => JsInterop?.Get(MediaId);
    public void Play()
    {
        _ = (JsInterop?.Play(MediaId));
    }

    public void Pause()
    {
        _ = (JsInterop?.Pause(MediaId));
    }

    public void SetMuted(bool muted)
    {
        _ = (JsInterop?.SetMuted(MediaId, muted));
    }

    public void SetLoop(bool loop)
    {
        _ = (JsInterop?.SetLoop(MediaId, loop));
    }

    public void SetCurrentTime(int currentTime)
    {
        _ = (JsInterop?.SetCurrentTime(MediaId, currentTime));
    }

    public void SetVolume(double volume)
    {
        _ = (JsInterop?.SetVolume(MediaId, volume));
    }

    public void SetFullscreen(bool fullscreen)
    {
        _ = (JsInterop?.SetFullscreen(MediaId, fullscreen));
    }
}

