var core = angular.module("core", ["ngHelperBusy", 'ui.bootstrap', 'angularTrix'])
    .constant('keyCodes', {
        esc: 27,
        space: 32,
        enter: 13,
        tab: 9,
        backspace: 8,
        shift: 16,
        ctrl: 17,
        alt: 18,
        capslock: 20,
        numlock: 144
    }).constant('templates', {
        Domain: '',
    })
    .constant("appSettings", {
        "serviceUrl": function (currentUrl) {
            var url = currentUrl.indexOf("localhost") > -1 ? "http://localhost:19532/" : window.location.origin;
            return url;
        },

        "PostFile": "/Home/UploadFile?description=",
        "GetAllImages": "/Home/GetAllImages",
        "GetImageById": "/Home/GetImage/",
        "UpdateDescription": "/Home/UpdateFile?"
    });

//Services

core.service('requestHelper', requestHelper);
core.service('spinnerService', spinnerService);
core.service('imageService', imageService);
core.service('exifService', exifService);

spinnerService.$inject = ['$timeout', '$busy'];
imageService.$inject = ['appSettings', 'requestHelper', 'spinnerService'];
requestHelper.$inject = ['$http', '$q', 'appSettings', '$window'];

//Derectives

core.directive('uploadFile', uploadFile);
core.directive('getFileExif', getFileExif);
core.directive('selectImage', selectImage);
core.directive('loadImage', loadImage);

selectImage.$inject = ['$http', 'appSettings', 'imageService', 'exifService'];
loadImage.$inject = ['imageService', 'exifService'];
getFileExif.$inject = ['exifService'];
uploadFile.$inject = ['imageService', '$location', '$anchorScroll'];