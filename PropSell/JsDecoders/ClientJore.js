//---> int id
//---> string TellNo
//---> string Identification
function AddClient(client)
{
    return Bjax('/api/ClientCore/AddClient', client, 'LP');
}
function DeleteClient(id)
{
    return Bjax('/api/ClientCore/DeleteClient?id=', id, 'SP');
}
function UpdateClient(client, logId)
{
    var clientLogId = new Array();
    clientLogId.push(client);
    clientLogId.push(logId);
    return Bjax('/api/ClientCore/UpdateClient', clientLogId, 'LP');
}
function SelectAllClients()
{
    return Bjax('/api/ClientCore/SelectAllClients', '', 'G');
}
function SelectClientById(id)
{
    return Bjax('/api/ClientCore/SelectClientById?id=', id, 'SP');
}
function SelectClientByTellNo(tellNo)
{
    return Bjax('/api/ClientCore/SelectClientByTellNo?tellNo=', tellNo, 'SP');
}
function SelectClientByIdentification(identification)
{
    return Bjax('/api/ClientCore/SelectClientByIdentification?identification=', identification, 'SP');
}
