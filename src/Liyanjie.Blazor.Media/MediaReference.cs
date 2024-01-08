namespace Liyanjie.Blazor.Media;

public class MediaReference(
    string mediaId,
    MediaController controller)
{
    public bool Paused { get; private set; }
    public bool Controls { get; private set; }
    public bool Loop { get; private set; }
    public bool Muted { get; private set; }
    public bool IsFullscreen { get; private set; }
    public bool IsPictureInPicture { get; private set; }

    public async ValueTask<MediaObject> GetObjectAsync() => (await controller.GetAsync(mediaId))!;
    public async ValueTask<TValue?> ValueAsync<TValue>(string name) => await controller.ValueAsync<TValue>(mediaId, name);
    public async Task PlayAsync()
    {
        await controller.PlayAsync(mediaId);
        Paused = await ValueAsync<bool>("paused");
    }
    public async Task PauseAsync()
    {
        await controller.PauseAsync(mediaId);
        Paused = await ValueAsync<bool>("paused");
    }
    public async Task MuteAsync()
    {
        await controller.MuteAsync(mediaId);
        Muted = await ValueAsync<bool>("muted");
    }
    public Task SetVolumeAsync(double volume) => controller.SetVolumeAsync(mediaId, volume);
    public Task SetCurrentTimeAsync(int currentTime) => controller.SetCurrentTimeAsync(mediaId, currentTime);
    public async Task ToggleControlsAsync()
    {
        await controller.SetControlsAsync(mediaId, !Controls);
        Controls = await ValueAsync<bool>("controls");
    }
    public async Task ToggleLoopAsync()
    {
        await controller.SetLoopAsync(mediaId, !Loop);
        Loop = await ValueAsync<bool>("loop");
    }
    public async Task ToggleMutedAsync()
    {
        await controller.SetMutedAsync(mediaId, !Muted);
        Muted = await ValueAsync<bool>("muted");
    }
    public async Task ToggleFullscreenAsync()
    {
        await controller.SetFullscreenAsync(mediaId, !IsFullscreen);
        IsFullscreen = await controller.IsFullscreenAsync();
    }
    public async Task TogglePictureInPictureAsync()
    {
        await controller.SetPictureInPictureAsync(mediaId, !IsPictureInPicture);
        IsPictureInPicture = await controller.IsPictureInPictureAsync();
    }

    public async Task LoadAsync()
    {
        Paused = await ValueAsync<bool>("paused");
        Controls = await ValueAsync<bool>("controls");
        Loop = await ValueAsync<bool>("loop");
        Muted = await ValueAsync<bool>("muted");
        IsFullscreen = await controller.IsFullscreenAsync();
        IsPictureInPicture = await controller.IsPictureInPictureAsync();
    }
}
