using Microsoft.JSInterop;

namespace Liyanjie.Blazor.Medias
{
    public class MediaController : IAsyncDisposable
    {
        readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public MediaController(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Liyanjie.Blazor.Medias/js.js").AsTask());
        }

        public async ValueTask<MediaObject> Get(string mediaId)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<MediaObject>("$blazor_media.get", mediaId);
        }
        public async ValueTask Play(string mediaId)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.play", mediaId);
        }
        public async ValueTask Pause(string mediaId)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.pause", mediaId);
        }
        public async ValueTask SetMuted(string mediaId, bool muted)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setMuted", mediaId, muted);
        }
        public async ValueTask SetLoop(string mediaId, bool loop)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setLoop", mediaId, loop);
        }
        public async ValueTask SetCurrentTime(string mediaId, int currentTime)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setCurrentTime", mediaId, currentTime);
        }
        public async ValueTask SetVolume(string mediaId, double volume)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setVolume", mediaId, volume);
        }
        public async ValueTask SetFullscreen(string mediaId, bool fullscreen)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("$blazor_media.setFullscreen", mediaId, fullscreen);
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
}