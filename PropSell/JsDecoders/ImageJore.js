//---> int id
//---> string Name
function AddImage(image)
{
    return Bjax('/api/ImageCore/AddImage', image, 'LP');
}
function DeleteImage(id)
{
    return Bjax('/api/ImageCore/DeleteImage?id=', id, 'SP');
}
function UpdateImage(image, logId)
{
    var imageLogId = new Array();
    imageLogId.push(image);
    imageLogId.push(logId);
    return Bjax('/api/ImageCore/UpdateImage', imageLogId, 'LP');
}
function SelectAllImages()
{
    return Bjax('/api/ImageCore/SelectAllImages', '', 'G');
}
function SelectImageById(id)
{
    return Bjax('/api/ImageCore/SelectImageById?id=', id, 'SP');
}
function SelectImageByName(name)
{
    return Bjax('/api/ImageCore/SelectImageByName?name=', name, 'SP');
}
