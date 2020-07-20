//---> int id
//---> int PropertyId
//---> int ImageId
function AddPropertyImageRel(propertyImageRel)
{
    return Bjax('/api/PropertyImageRelCore/AddPropertyImageRel', propertyImageRel, 'LP');
}
function DeletePropertyImageRel(id)
{
    return Bjax('/api/PropertyImageRelCore/DeletePropertyImageRel?id=', id, 'SP');
}
function UpdatePropertyImageRel(propertyImageRel, logId)
{
    var propertyImageRelLogId = new Array();
    propertyImageRelLogId.push(propertyImageRel);
    propertyImageRelLogId.push(logId);
    return Bjax('/api/PropertyImageRelCore/UpdatePropertyImageRel', propertyImageRelLogId, 'LP');
}
function SelectAllPropertyImageRels()
{
    return Bjax('/api/PropertyImageRelCore/SelectAllPropertyImageRels', '', 'G');
}
function SelectPropertyImageRelById(id)
{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelById?id=', id, 'SP');
}
function SelectPropertyImageRelByPropertyId(propertyId)
{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelByPropertyId?propertyId=', propertyId, 'SP');
}
function SelectPropertyImageRelByImageId(imageId)
{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelByImageId?imageId=', imageId, 'SP');
}
