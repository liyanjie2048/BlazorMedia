using Microsoft.JSInterop;

namespace Liyanjie.Blazor.Medias
{
    public class JsInterop : IAsyncDisposable
    {
        readonly Lazy<Task<IJSObjectReference>> _moduleTask;

        public JsInterop(IJSRuntime jsRuntime)
        {
            _moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Liyanjie.Blazor.Medias/js.js").AsTask());
        }

        static string GetId(string? id) => id ?? string.Empty;

        public async ValueTask<MediaObject> Get(string? id)
        {
            var module = await _moduleTask.Value;
            return await module.InvokeAsync<MediaObject>("media.get", GetId(id));
        }
        public async ValueTask Play(string? id)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.play", GetId(id));
        }
        public async ValueTask Pause(string? id)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.pause", GetId(id));
        }
        public async ValueTask SetMuted(string? id, bool muted)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.setMuted", GetId(id), muted);
        }
        public async ValueTask SetLoop(string? id, bool loop)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.setLoop", GetId(id), loop);
        }
        public async ValueTask SetCurrentTime(string? id, int currentTime)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.setCurrentTime", GetId(id), currentTime);
        }
        public async ValueTask SetVolume(string? id, double volume)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.setVolume", GetId(id), volume);
        }
        public async ValueTask SetFullscreen(string? id, bool fullscreen)
        {
            var module = await _moduleTask.Value;
            await module.InvokeVoidAsync("media.setFullscreen", GetId(id), fullscreen);
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