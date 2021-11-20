using Microsoft.AspNetCore.Components;

namespace Liyanjie.Blazor.Medias;

public class MediaRecognizer : ComponentBase
{
    [Inject] JsInterop? JsInterop { get; set; }
    [Parameter] public string? MediaId { get; set; }

    public ValueTask<MediaObject>? Get() => JsInterop?.Get(MediaId);
    public void Play() => JsInterop?.Play(MediaId);
    public void Pause() => JsInterop?.Pause(MediaId);
    public void SetMuted(bool muted) => JsInterop?.SetMuted(MediaId, muted);
    public void SetLoop(bool loop) => JsInterop?.SetLoop(MediaId, loop);
    public void SetCurrentTime(int currentTime) => JsInterop?.SetCurrentTime(MediaId, currentTime);
    public void SetVolume(double volume) => JsInterop?.SetVolume(MediaId, volume);
    public void SetFullscreen(bool fullscreen) => JsInterop?.SetFullscreen(MediaId, fullscreen);
}

