# Liyanjie.Blazor.Medias

Blazor媒体控制（Blazor video/audio controller）

- #### MediaRecognizer
    注册媒体元素识别器
  - Usage
    ```html
    @Inject MediaController MediaController

    <video id="myId" width="640" height="360">
        <source src="video.mp4" />
    </video>
    <div>
        <button @onclick=@(()=>MediaController?.GetAsync("myId"))>GetVideo</button>
        <button @onclick=@(()=>MediaController?.PlayAsync("myId"))>PLAY</button>
        <button @onclick=@(()=>MediaController?.PauseAsync("myId"))>PAUSE</button>
        <button @onclick=@(()=>MediaController?.MuteAsync("myId"))>PAUSE</button>
        <button @onclick=@(()=>MediaController?.SetMutedAsync("myId",true|false))>MUTED</button>
        <button @onclick=@(()=>MediaController?.SetVolumeAsync("myId",0~1))>Volume</button>
        <button @onclick=@(()=>MediaController?.SetLoopAsync("myId",true|false))>LOOP</button>
        <button @onclick=@(()=>MediaController?.SetCurrentTimeAsync("myId",int))>SetCurrentTime</button>
        <button @onclick=@(()=>MediaController?.SetFullscreenAsync("myId",true|false))>FULLSCREEN</button>
    </div>
    @code{
    }
    ```