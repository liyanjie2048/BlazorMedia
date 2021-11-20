# Liyanjie.Blazor.Medias

Blazor媒体控制（Blazor video/audio controller/recognizer）

- #### MediaRecognizer
    注册媒体元素识别器
  - Usage
    ```html
    <video id="myId" width="640" height="360">
        <source src="video.mp4" />
    </video>
    <MediaRecognizer MediaId=@("myId") @ref=@(video) />
    <div>
        <button @onclick=@(()=>Print(video?.Get()))>GetVideo</button>
        <button @onclick=@(()=>video?.Play())>PLAY</button>
        <button @onclick=@(()=>video?.Pause())>PAUSE</button>
        <button @onclick=@(()=>video?.SetLoop(true|false))>LOOP</button>
        <button @onclick=@(()=>video?.SetMuted(true|false))>MUTED</button>
        <button @onclick=@(()=>video?.SetVolume(0~1))>LOOP</button>
        <button @onclick=@(()=>video?.SetCurrentTime(int))>MUTED</button>
        <button @onclick=@(()=>video?.SetFullscreen(true|false))>FULLSCREEN</button>
    </div>
    @code{
        MediaRecognizer? video;
    }
    ```