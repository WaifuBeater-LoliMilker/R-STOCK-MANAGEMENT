$(() => {
    var isLoading = false
    $('#demo').on('click', function () {
        isLoading = !isLoading;
        if (isLoading) run_waitMe('bounce');
        else run_waitMe('hide');
    });

    function run_waitMe(effect) {
        if (effect == 'hide') {
            $('#app').waitMe('hide');
            return;
        }
        $('#app').waitMe({
            effect: effect,
            text: 'Loading',
            bg: 'rgba(255,255,255,0.7)',
            color: '#000',
            maxSize: '',
            waitTime: -1,
            source: '',
            textPos: 'vertical',
            fontSize: '',
            onClose: function () { }
        });
    }
    $('#code').trigger('focus')
})