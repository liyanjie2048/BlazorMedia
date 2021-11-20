export var media = {
    get(id) {
        var m = document.getElementById(id);
        return {
            autoplay: m.autoplay,
            controls: m.controls,
            crossorigin: m.crossorigin,
            preload: m.preload,
            loop: m.loop,
            muted: m.muted,
            duration: m.duration,
            currentTime: m.currentTime,
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
