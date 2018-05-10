function spinnerService($timeout, $busy) {
    return {
        show: function (elementId, loadingText) {
            $busy.beBusy();

        },
        hide: function (elementId, doneText) {
            $busy.beFree();
        },
        during: function (promise) {
            return $busy.during(promise);
        }
    };
};