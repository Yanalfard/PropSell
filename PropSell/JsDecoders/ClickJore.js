//---> int id
//---> string Date
//---> int PropertyId
function AddClick(click)
{
    return Bjax('/api/ClickCore/AddClick', click, 'LP');
}
function DeleteClick(id)
{
    return Bjax('/api/ClickCore/DeleteClick?id=', id, 'SP');
}
function UpdateClick(click, logId)
{
    var clickLogId = new Array();
    clickLogId.push(click);
    clickLogId.push(logId);
    return Bjax('/api/ClickCore/UpdateClick', clickLogId, 'LP');
}
function SelectAllClicks()
{
    return Bjax('/api/ClickCore/SelectAllClicks', '', 'G');
}
function SelectClickById(id)
{
    return Bjax('/api/ClickCore/SelectClickById?id=', id, 'SP');
}
function SelectClickByPropertyId(propertyId)
{
    return Bjax('/api/ClickCore/SelectClickByPropertyId?propertyId=', propertyId, 'SP');
}
