window.setFocus = (element) => {
    if (element) {
        element.focus();
    }
};
var isLoading = false
function toggleLoading(updateValue) {
    isLoading = updateValue;
    if (isLoading) run_waitMe('bounce');
    else run_waitMe('hide');
}

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
function selectAllText(element) {
    element.select();
}