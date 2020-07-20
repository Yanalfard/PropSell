//---> int id
//---> string TellNo
//---> string Identification
//---> string Address

{
    return Bjax('/api/ConstructorCore/AddConstructor', constructor, 'LP');
}

{
    return Bjax('/api/ConstructorCore/DeleteConstructor?id=', id, 'SP');
}

{
    var constructorLogId = new Array();
    constructorLogId.push(constructor);
    constructorLogId.push(logId);
    return Bjax('/api/ConstructorCore/UpdateConstructor', constructorLogId, 'LP');
}

{
    return Bjax('/api/ConstructorCore/SelectAllConstructors', '', 'G');
}

{
    return Bjax('/api/ConstructorCore/SelectConstructorById?id=', id, 'SP');
}

{
    return Bjax('/api/ConstructorCore/SelectConstructorByTellNo?tellNo=', tellNo, 'SP');
}

{
    return Bjax('/api/ConstructorCore/SelectConstructorByIdentification?identification=', identification, 'SP');
}
