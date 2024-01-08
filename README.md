# Liyanjie.Blazor.Media

BlazorÃ½Ìå¿ØÖÆ£¨Blazor video/audio controller£©

  - Usage
    ```razor
    @inject MediaController MediaController

    <video id="VIDEO" width="640" height="360">
        <source src="video.mp4" />
    </video>
    <div>
        <button @onclick=@(()=>MediaController.GetAsync("VIDEO"))>GetVideo</button>
        <button @onclick=@(()=>MediaController.PlayAsync("VIDEO"))>PLAY</button>
        <button @onclick=@(()=>MediaController.PauseAsync("VIDEO"))>PAUSE</button>
        <button @onclick=@(()=>MediaController.MuteAsync("VIDEO"))>MUTE</button>
        <button @onclick=@(()=>MediaController.SetVolumeAsync("VIDEO",0~1))>SetVolume</button>
        <button @onclick=@(()=>MediaController.SetControlsAsync("VIDEO",true|false))>SetControls</button>
        <button @onclick=@(()=>MediaController.SetLoopAsync("VIDEO",true|false))>SetLoop</button>
        <button @onclick=@(()=>MediaController.SetMutedAsync("VIDEO",true|false))>SetMuted</button>
        <button @onclick=@(()=>MediaController.SetFullscreenAsync("VIDEO",true|false))>SetFullscreen</button>
        <button @onclick=@(()=>MediaController.SetCurrentTimeAsync("VIDEO",int))>SetCurrentTime</button>
    </div>
    ```
  - Also
    ```razor
    <video id="VIDEO" width="640" height="360" preload="metadata" controls loop muted>
        <source src="/video.mp4" />
    </video>
    @if (video is not null)
    {
        <div>
            <button @onclick=@(()=>PrintAsync(video.GetObjectAsync()))>GetVideo</button>
            <button @onclick=@(()=>video.PlayAsync())>PLAY</button>
            <button @onclick=@(()=>video.PauseAsync())>PAUSE</button>
            <button @onclick=@(()=>video.ToggleControlsAsync())>CONTROLS</button>
            <button @onclick=@(()=>video.ToggleLoopAsync())>LOOP</button>
            <button @onclick=@(()=>video.ToggleMutedAsync())>MUTED</button>
            <button @onclick=@(()=>video.ToggleFullscreenAsync())>FULLSCREEN</button>
            <button @onclick=@(()=>video.TogglePictureInPictureAsync())>PictureInPicture</button>
        </div>
    }
    @code{
        MediaReference? video;
        protected override void OnInitialized()
        {
            base.OnInitialized();
            video = new("VIDEO", MediaController);
        }
    }
    ```