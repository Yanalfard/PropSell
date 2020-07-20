//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood
function AddProperty(property)
{
    return Bjax('/api/PropertyCore/AddProperty', property, 'LP');
}
function DeleteProperty(id)
{
    return Bjax('/api/PropertyCore/DeleteProperty?id=', id, 'SP');
}
function UpdateProperty(property, logId)
{
    var propertyLogId = new Array();
    propertyLogId.push(property);
    propertyLogId.push(logId);
    return Bjax('/api/PropertyCore/UpdateProperty', propertyLogId, 'LP');
}
function SelectAllPropertys()
{
    return Bjax('/api/PropertyCore/SelectAllPropertys', '', 'G');
}
function SelectPropertyById(id)
{
    return Bjax('/api/PropertyCore/SelectPropertyById?id=', id, 'SP');
}
function SelectPropertyByTitle(title)
{
    return Bjax('/api/PropertyCore/SelectPropertyByTitle?title=', title, 'SP');
}
function SelectPropertyByValid(valid)
{
    return Bjax('/api/PropertyCore/SelectPropertyByValid?valid=', valid, 'SP');
}
function SelectPropertyByShowToFriends(showToFriends)
{
    return Bjax('/api/PropertyCore/SelectPropertyByShowToFriends?showToFriends=', showToFriends, 'SP');
}
function SelectPropertyByUserId(userId)
{
    return Bjax('/api/PropertyCore/SelectPropertyByUserId?userId=', userId, 'SP');
}
function SelectPropertyByCityId(cityId)
{
    return Bjax('/api/PropertyCore/SelectPropertyByCityId?cityId=', cityId, 'SP');
}
function SelectImageByPropertyId(propertyId)
{
    return Bjax('/api/ImageCore/SelectImageByPropertyId?propertyId=', propertyId, 'SP');
}
function SelectClientByPropertyId(propertyId)
{
    return Bjax('/api/ClientCore/SelectClientByPropertyId?propertyId=', propertyId, 'SP');
}
