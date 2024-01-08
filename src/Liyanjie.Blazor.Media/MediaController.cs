namespace Liyanjie.Blazor.Media;

public class MediaController(IJSRuntime jsRuntime) : IAsyncDisposable
{
    readonly Lazy<Task<IJSObjectReference>> _moduleTask
        = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Liyanjie.Blazor.Media/js.js").AsTask());

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
    public async ValueTask<TValue?> ValueAsync<TValue>(string mediaId, string name)
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<TValue>("$blazor_media.value", mediaId, name);
        }
        catch (Exception)
        {
            return default;
        }
    }
    public async Task PlayAsync(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.play", mediaId);
        }
        catch (Exception) { }
    }
    public async Task PauseAsync(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.pause", mediaId);
        }
        catch (Exception) { }
    }
    public async Task MuteAsync(string mediaId)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setMuted", mediaId, true);
        }
        catch (Exception) { }
    }
    public async Task SetMutedAsync(string mediaId, bool muted)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setMuted", mediaId, muted);
        }
        catch (Exception) { }
    }
    public async Task SetVolumeAsync(string mediaId, double volume)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setVolume", mediaId, volume);
        }
        catch (Exception) { }
    }
    public async Task SetControlsAsync(string mediaId, bool controls)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setControls", mediaId, controls);
        }
        catch (Exception) { }
    }
    public async Task SetLoopAsync(string mediaId, bool loop)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setLoop", mediaId, loop);
        }
        catch (Exception) { }
    }
    public async Task SetCurrentTimeAsync(string mediaId, int currentTime)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setCurrentTime", mediaId, currentTime);
        }
        catch (Exception) { }
    }
    public async ValueTask<bool> IsFullscreenAsync()
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("$blazor_media.isFullscreen");
        }
        catch (Exception) { }
        return default;
    }
    public async Task SetFullscreenAsync(string mediaId, bool fullscreen)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setFullscreen", mediaId, fullscreen);
        }
        catch (Exception) { }
    }
    public async ValueTask<bool> IsPictureInPictureAsync()
    {
        try
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<bool>("$blazor_media.isPictureInPicture");
        }
        catch (Exception) { }
        return default;
    }
    public async Task SetPictureInPictureAsync(string mediaId, bool pictureInPicture)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setPictureInPicture", mediaId, pictureInPicture);
        }
        catch (Exception) { }
    }
    public async Task CallAsync(string mediaId, string name)
    {
        try
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.call", mediaId, name);
        }
        catch (Exception) { }
    }

#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
    public async ValueTask DisposeAsync()
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
    {
        if (_moduleTask.IsValueCreated)
        {
            var module = await _moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}
