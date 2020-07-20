//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood

{
    return Bjax('/api/PropertyCore/AddProperty', property, 'LP');
}

{
    return Bjax('/api/PropertyCore/DeleteProperty?id=', id, 'SP');
}

{
    var propertyLogId = new Array();
    propertyLogId.push(property);
    propertyLogId.push(logId);
    return Bjax('/api/PropertyCore/UpdateProperty', propertyLogId, 'LP');
}

{
    return Bjax('/api/PropertyCore/SelectAllPropertys', '', 'G');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyById?id=', id, 'SP');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyByTitle?title=', title, 'SP');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyByValid?valid=', valid, 'SP');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyByShowToFriends?showToFriends=', showToFriends, 'SP');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyByUserId?userId=', userId, 'SP');
}

{
    return Bjax('/api/PropertyCore/SelectPropertyByCityId?cityId=', cityId, 'SP');
}

{
    return Bjax('/api/ImageCore/SelectImageByPropertyId?propertyId=', propertyId, 'SP');
}

{
    return Bjax('/api/ClientCore/SelectClientByPropertyId?propertyId=', propertyId, 'SP');
}
