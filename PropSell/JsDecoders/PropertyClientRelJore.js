//---> int id
//---> int PropertyId
//---> int UserId
//---> int Status
function AddPropertyClientRel(propertyClientRel)
{
    return Bjax('/api/PropertyClientRelCore/AddPropertyClientRel', propertyClientRel, 'LP');
}
function DeletePropertyClientRel(id)
{
    return Bjax('/api/PropertyClientRelCore/DeletePropertyClientRel?id=', id, 'SP');
}
function UpdatePropertyClientRel(propertyClientRel, logId)
{
    var propertyClientRelLogId = new Array();
    propertyClientRelLogId.push(propertyClientRel);
    propertyClientRelLogId.push(logId);
    return Bjax('/api/PropertyClientRelCore/UpdatePropertyClientRel', propertyClientRelLogId, 'LP');
}
function SelectAllPropertyClientRels()
{
    return Bjax('/api/PropertyClientRelCore/SelectAllPropertyClientRels', '', 'G');
}
function SelectPropertyClientRelById(id)
{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelById?id=', id, 'SP');
}
function SelectPropertyClientRelByPropertyId(propertyId)
{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByPropertyId?propertyId=', propertyId, 'SP');
}
function SelectPropertyClientRelByUserId(userId)
{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByUserId?userId=', userId, 'SP');
}
function SelectPropertyClientRelByStatus(status)
{
    return Bjax('/api/PropertyClientRelCore/SelectPropertyClientRelByStatus?status=', status, 'SP');
}
