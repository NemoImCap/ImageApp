function uploadFile(imageService, $location, $anchorScroll) {
    return {
        restrict: 'A',
        link: function (scope, elem, attr) {
            elem.on("click", function (evt) {
                var formdata = $('#image');
                var foundForm = formdata.get(0);
                var files = foundForm[0].files;

                // Create FormData object  
                var fileData = new FormData();

                // Looping over all files and add it to FormData object  
                for (var i = 0; i < files.length; i++) {
                    fileData.append(files[i].name, files[i]);
                }
                if (files.length) {
                    $location.hash('top');
                    $anchorScroll();
                    imageService.UploadImage(fileData, scope.updateModel.description).then(function (response) {
                        scope.loadImages();
                        scope.showEdit = false;
                        scope.updateModel.description = "";
                    });
                } else {
                    console.log("no files");
                }
            });
        }
    }
}