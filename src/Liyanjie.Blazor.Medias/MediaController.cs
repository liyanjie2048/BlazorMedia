using Microsoft.JSInterop;

namespace Liyanjie.Blazor.Medias;

public class MediaController : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public MediaController(IJSRuntime jsRuntime)
    {
        _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Liyanjie.Blazor.Medias/js.js").AsTask());
    }

    public async ValueTask<MediaObject?> GetAsync(string mediaId)
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
    public async ValueTask PlayAsync(params string[] mediaIds)
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
    public async ValueTask PauseAsync(params string[] mediaIds)
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
    public async ValueTask MuteAsync(params string[] mediaIds)
    {
        if (mediaIds is not null)
            foreach (var mediaId in mediaIds)
            {
                await SetMutedAsync(mediaId, true);
            }
    }
    public async ValueTask SetMutedAsync(string mediaId, bool muted)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setMuted", mediaId, muted);
        }
        catch (Exception) { }
    }
    public async ValueTask SetVolumeAsync(string mediaId, double volume)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setVolume", mediaId, volume);
        }
        catch (Exception) { }
    }
    public async ValueTask SetLoopAsync(string mediaId, bool loop)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setLoop", mediaId, loop);
        }
        catch (Exception) { }
    }
    public async ValueTask SetCurrentTimeAsync(string mediaId, int currentTime)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setCurrentTime", mediaId, currentTime);
        }
        catch (Exception) { }
    }
    public async ValueTask SetFullscreenAsync(string mediaId, bool fullscreen)
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
