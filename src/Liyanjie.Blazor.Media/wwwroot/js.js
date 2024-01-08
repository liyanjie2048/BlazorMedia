export var $blazor_media = {
    get(mediaId)
    {
        console.log(`blazor_media:get----------${mediaId}`);
        try
        {
            let m = document.getElementById(mediaId);
            return {
                autoplay: m.autoplay,
                controls: m.controls,
                crossorigin: m.crossorigin,
                currentTime: m.currentTime,
                duration: m.duration,
                loop: m.loop,
                muted: m.muted,
                preload: m.preload,
                volume: m.volume,
            };
        } catch (exception) { }
    },
    value(id, name)
    {
        console.log(`blazor_media:value----------${id}`);
        try
        {
            const m = document.getElementById(id);
            return m && m[name];
        } catch (ex) { }
    },
    play(id)
    {
        console.log(`blazor_media:play----------${id}`);
        try
        {
            document.getElementById(id)?.play();
        } catch (ex) { }
    },
    pause(id)
    {
        console.log(`blazor_media:pause----------${id}`);
        try
        {
            document.getElementById(id)?.pause();
        } catch (ex) { }
    },
    setMuted(id, muted)
    {
        console.log(`blazor_media:setMuted----------${id}`);
        try
        {
            const m = document.getElementById(id);
            m && (m.muted = muted);
        } catch (ex) { }
    },
    setVolume(id, volume)
    {
        console.log(`blazor_media:setVolume----------${id}`);
        try
        {
            const m = document.getElementById(id);
            if (m)
            {
                m.muted = volume == 0;
                m.volume = volume;
            }
        } catch (ex) { }
    },
    setControls(id, controls)
    {
        console.log(`blazor_media:setControls----------${id}`);
        try
        {
            const m = document.getElementById(id);
            m && (m.controls = controls);
        } catch (ex) { }
    },
    setLoop(id, loop)
    {
        console.log(`blazor_media:setLoop----------${id}`);
        try
        {
            const m = document.getElementById(id);
            m && (m.loop = loop);
        } catch (ex) { }
    },
    setCurrentTime(id, currentTime)
    {
        console.log(`blazor_media:setCurrentTime----------${id}`);
        try
        {
            const m = document.getElementById(id);
            m && (m.currentTime = currentTime);
        } catch (ex) { }
    },
    call(id, name)
    {
        console.log(`blazor_media:call----------${id}`);
        try
        {
            const m = document.getElementById(id);
            m && m[name] && typeof m[name] === 'function' && m[name]();
        } catch (ex) { }
    },
    isFullscreen()
    {
        const value = document.fullscreenElement ? true : false;
        console.log(`blazor_media:isFullscreen----------${value}`);
        return value;
    },
    async setFullscreen(id, fullscreen)
    {
        console.log(`blazor_media:setFullscreen----------${id}`);
        try
        {
            if (fullscreen && document.fullscreenEnabled)
            {
                const m = document.getElementById(id);
                m && await m.requestFullscreen();
            }
            else if (document.fullscreenElement)
                await document.exitFullscreen();
        } catch (ex) { }
    },
    isPictureInPicture()
    {
        const value = document.pictureInPictureElement ? true : false;
        console.log(`blazor_media:isPictureInPicture----------${value}`);
        return value;
    },
    async setPictureInPicture(id, pictureInPicture)
    {
        console.log(`blazor_media:setPictureInPicture----------${id}`);
        try
        {
            if (pictureInPicture && document.pictureInPictureEnabled)
            {
                const m = document.getElementById(id);
                m && await m.requestPictureInPicture();
            }
            else if (document.pictureInPictureElement)
                await document.exitPictureInPicture();
        } catch (ex) { }
    },
};
