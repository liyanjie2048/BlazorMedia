using Microsoft.JSInterop;

namespace Liyanjie.Blazor.Medias;

public class MediaController : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public MediaController(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Liyanjie.Blazor.Medias/js.js").AsTask());
    }

    public async ValueTask<MediaObject?> Get(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<MediaObject>("$blazor_media.get", mediaId);
        }
        catch (Exception)
        {
            return default;
        }
    }
    public async ValueTask Play(params string[] mediaIds)
    {
        if (mediaIds is not null)
            try
            {
                var module = await _moduleTask.Value;
                foreach (var mediaId in mediaIds)
                {
                    try
                    {
                        await module.InvokeVoidAsync("$blazor_media.play", mediaId);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
    }
    public async ValueTask Pause(params string[] mediaIds)
    {
        if (mediaIds is not null)
            try
            {
                var module = await _moduleTask.Value;
                foreach (var mediaId in mediaIds)
                {
                    try
                    {
                        await module.InvokeVoidAsync("$blazor_media.pause", mediaId);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
    }
    public async ValueTask Mute(params string[] mediaIds)
    {
        if (mediaIds is not null)
            try
            {
                var module = await _moduleTask.Value;
                foreach (var mediaId in mediaIds)
                {
                    try
                    {
                        await module.InvokeVoidAsync("$blazor_media.mute", mediaId);
                    }
                    catch (Exception) { }
                }
            }
            catch (Exception) { }
    }
    public async ValueTask VolumeUp(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.volumeUp", mediaId);
        }
        catch (Exception) { }
    }
    public async ValueTask VolumeDown(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.volumeDown", mediaId);
        }
        catch (Exception) { }
    }
    public async ValueTask SetVolume(string mediaId, double volume)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setVolume", mediaId, volume);
        }
        catch (Exception) { }
    }
    public async ValueTask SetLoop(string mediaId, bool loop)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setLoop", mediaId, loop);
        }
        catch (Exception) { }
    }
    public async ValueTask SetCurrentTime(string mediaId, int currentTime)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setCurrentTime", mediaId, currentTime);
        }
        catch (Exception) { }
    }
    public async ValueTask SetFullscreen(string mediaId, bool fullscreen)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setFullscreen", mediaId, fullscreen);
        }
        catch (Exception) { }
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
