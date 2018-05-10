function imageService(appSettings, requestHelper, spinnerService) {
    var self = {};


    self.UploadImage = function (file, description) {
        var promise = spinnerService.during(requestHelper.post(appSettings.PostFile + description, file));
        return promise;
    }

    self.GetAllImages = function () {
        var promise = spinnerService.during(requestHelper.get(appSettings.GetAllImages, ""));
        return promise;
    }

    self.UpdateDescription = function (model) {
        var promise = spinnerService.during(requestHelper.post(appSettings.UpdateDescription + "id=" + model.id + "&description=" + model.description, ""));
        return promise;
    }

    self.GetImageById = function (id) {
        var promise = spinnerService.during(requestHelper.get(appSettings.GetImageById + id, "", "blob"));
        return promise;
    }
    return self;
}