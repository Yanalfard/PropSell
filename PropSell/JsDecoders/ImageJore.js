//---> int id
//---> string Name

{
    return Bjax('/api/ImageCore/AddImage', image, 'LP');
}

{
    return Bjax('/api/ImageCore/DeleteImage?id=', id, 'SP');
}

{
    var imageLogId = new Array();
    imageLogId.push(image);
    imageLogId.push(logId);
    return Bjax('/api/ImageCore/UpdateImage', imageLogId, 'LP');
}

{
    return Bjax('/api/ImageCore/SelectAllImages', '', 'G');
}

{
    return Bjax('/api/ImageCore/SelectImageById?id=', id, 'SP');
}

{
    return Bjax('/api/ImageCore/SelectImageByName?name=', name, 'SP');
}
