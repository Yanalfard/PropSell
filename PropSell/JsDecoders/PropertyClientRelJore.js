//---> int id
//---> int PropertyId
//---> int UserId
//---> int Status

{
    return Bjax('/api/PropertyClientRelCore/AddPropertyClientRel', propertyClientRel, 'LP');
}

{
    return Bjax('/api/PropertyClientRelCore/DeletePropertyClientRel?id=', id, 'SP');
}

{
    var propertyClientRelLogId = new Array();
    propertyClientRelLogId.push(propertyClientRel);
    propertyClientRelLogId.push(logId);
    return Bjax('/api/PropertyClientRelCore/UpdatePropertyClientRel', propertyClientRelLogId, 'LP');
}

{
    return Bjax('/api/PropertyClientRelCore/SelectAllPropertyClientRels', '', 'G');
}

{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelById?id=', id, 'SP');
}

{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByPropertyId?propertyId=', propertyId, 'SP');
}

{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByUserId?userId=', userId, 'SP');
}

{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByStatus?status=', status, 'SP');
}
