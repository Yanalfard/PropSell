//---> int id
//---> int PropertyId
//---> int ImageId

{
    return Bjax('/api/PropertyImageRelCore/AddPropertyImageRel', propertyImageRel, 'LP');
}

{
    return Bjax('/api/PropertyImageRelCore/DeletePropertyImageRel?id=', id, 'SP');
}

{
    var propertyImageRelLogId = new Array();
    propertyImageRelLogId.push(propertyImageRel);
    propertyImageRelLogId.push(logId);
    return Bjax('/api/PropertyImageRelCore/UpdatePropertyImageRel', propertyImageRelLogId, 'LP');
}

{
    return Bjax('/api/PropertyImageRelCore/SelectAllPropertyImageRels', '', 'G');
}

{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelById?id=', id, 'SP');
}

{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelByPropertyId?propertyId=', propertyId, 'SP');
}

{
    return Bjax('/api/PropertyImageRelCore/SelectPropertyImageRelByImageId?imageId=', imageId, 'SP');
}
