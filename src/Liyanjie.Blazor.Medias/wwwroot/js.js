export var $blazor_media = {
    get(id) {
        var m = document.getElementById(id);
        console.log(m.volume);
        return {
            autoplay: m.autoplay,
            controls: m.controls,
            crossorigin: m.crossorigin,
            currentTime: m.currentTime,
            duration: m.duration,
            fullscreen: document.fullscreen,
            loop: m.loop,
            muted: m.muted,
            preload: m.preload,
            volume: m.volume,
        };
    },
    play(id) {
        document.getElementById(id)?.play();
    },
    pause(id) {
        document.getElementById(id)?.pause();
    },
    setMuted(id, muted) {
        var m = document.getElementById(id);
        m && (m.muted = muted);
    },
    setLoop(id, loop) {
        var m = document.getElementById(id);
        m && (m.loop = loop);
    },
    setCurrentTime(id, currentTime) {
        var m = document.getElementById(id);
        m && (m.currentTime = currentTime);
    },
    setVolume(id, volume) {
        var m = document.getElementById(id);
        m && (m.volume = volume);
    },
    setFullscreen(id, fullscreen) {
        if (fullscreen)
            document.getElementById(id)?.requestFullscreen();
        else
            document.exitFullscreen();
    }
};
