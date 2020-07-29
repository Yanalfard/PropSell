function Upload(formdata) {
    $.ajax({
        url: '/api/upload/uploadfile',
        type: 'POST',
        data: formdata,
        contentType: false,
        processData: false,
        success: function (imageName) {
            //var image = imageName.toString().split('_')[1] + imageName.toString().split('_')[2];
            return imageName;
        },

        error: function () {
            return false;
        }
    });
}
