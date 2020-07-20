//---> int id
//---> string TellNo
//---> string Identification
//---> string Address
function AddConstructor(constructor)
{
    return Bjax('/api/ConstructorCore/AddConstructor', constructor, 'LP');
}
function DeleteConstructor(id)
{
    return Bjax('/api/ConstructorCore/DeleteConstructor?id=', id, 'SP');
}
function UpdateConstructor(constructor, logId)
{
    var constructorLogId = new Array();
    constructorLogId.push(constructor);
    constructorLogId.push(logId);
    return Bjax('/api/ConstructorCore/UpdateConstructor', constructorLogId, 'LP');
}
function SelectAllConstructors()
{
    return Bjax('/api/ConstructorCore/SelectAllConstructors', '', 'G');
}
function SelectConstructorById(id)
{
    return Bjax('/api/ConstructorCore/SelectConstructorById?id=', id, 'SP');
}
function SelectConstructorByTellNo(tellNo)
{
    return Bjax('/api/ConstructorCore/SelectConstructorByTellNo?tellNo=', tellNo, 'SP');
}
function SelectConstructorByIdentification(identification)
{
    return Bjax('/api/ConstructorCore/SelectConstructorByIdentification?identification=', identification, 'SP');
}
