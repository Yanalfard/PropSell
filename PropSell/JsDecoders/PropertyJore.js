//---> int id
//---> string Title
//---> string Description
//---> bool Valid
//---> bool ShowToFriends
//---> int UserId
//---> int CityId
//---> string Neighborhood
//---> long Price


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
    return Bjax('/api/PropertyCore/SelectImagesByPropertyId?propertyId=', propertyId, 'SP');
}
function SelectClientByPropertyId(propertyId)
{
    return Bjax('/api/PropertyCore/SelectClientsByPropertyId?propertyId=', propertyId, 'SP');
}

function SelectLatestProperties(count)
{
    return Bjax('/api/PropertyCore/SelectLatestProperties?count=', count, 'SP');
}

function SelectFriendsProperties(meId)
{
    return Bjax('/api/PropertyCore/SelectFriendsProperties?meId=', meId, 'SP');
}

function SelectPropertiesByPriceBetween(min, max)
{
    var minMax = new Array();
    minMax.push(min);
    minMax.push(max);
    return Bjax('/api/PropertyCore/SelectPropertiesByPriceBetween?meId=', minMax, 'LP');
}