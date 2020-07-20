//---> int id
//---> string Date
//---> int PropertyId

{
    return Bjax('/api/ClickCore/AddClick', click, 'LP');
}

{
    return Bjax('/api/ClickCore/DeleteClick?id=', id, 'SP');
}

{
    var clickLogId = new Array();
    clickLogId.push(click);
    clickLogId.push(logId);
    return Bjax('/api/ClickCore/UpdateClick', clickLogId, 'LP');
}

{
    return Bjax('/api/ClickCore/SelectAllClicks', '', 'G');
}

{
    return Bjax('/api/ClickCore/SelectClickById?id=', id, 'SP');
}

{
    return Bjax('/api/ClickCore/SelectClickByPropertyId?propertyId=', propertyId, 'SP');
}
