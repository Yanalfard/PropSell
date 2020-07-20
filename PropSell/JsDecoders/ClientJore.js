//---> int id
//---> string TellNo
//---> string Identification

{
    return Bjax('/api/ClientCore/AddClient', client, 'LP');
}

{
    return Bjax('/api/ClientCore/DeleteClient?id=', id, 'SP');
}

{
    var clientLogId = new Array();
    clientLogId.push(client);
    clientLogId.push(logId);
    return Bjax('/api/ClientCore/UpdateClient', clientLogId, 'LP');
}

{
    return Bjax('/api/ClientCore/SelectAllClients', '', 'G');
}

{
    return Bjax('/api/ClientCore/SelectClientById?id=', id, 'SP');
}

{
    return Bjax('/api/ClientCore/SelectClientByTellNo?tellNo=', tellNo, 'SP');
}

{
    return Bjax('/api/ClientCore/SelectClientByIdentification?identification=', identification, 'SP');
}
