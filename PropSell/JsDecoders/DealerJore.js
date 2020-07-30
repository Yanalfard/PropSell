//---> int id
//---> string TellNo
//---> string Identification
//---> string Address
//---> string Name
function AddDealer(dealer)
{
    return Bjax('/api/DealerCore/AddDealer', dealer, 'LP');
}
function DeleteDealer(id)
{
    return Bjax('/api/DealerCore/DeleteDealer?id=', id, 'SP');
}
function UpdateDealer(dealer, logId)
{
    var dealerLogId = new Array();
    dealerLogId.push(dealer);
    dealerLogId.push(logId);
    return Bjax('/api/DealerCore/UpdateDealer', dealerLogId, 'LP');
}
function SelectAllDealers()
{
    return Bjax('/api/DealerCore/SelectAllDealers', '', 'G');
}
function SelectDealerById(id)
{
    return Bjax('/api/DealerCore/SelectDealerById?id=', id, 'SP');
}
function SelectDealerByTellNo(tellNo)
{
    return Bjax('/api/DealerCore/SelectDealerByTellNo?tellNo=', tellNo, 'SP');
}
function SelectDealerByIdentification(identification)
{
    return Bjax('/api/DealerCore/SelectDealerByIdentification?identification=', identification, 'SP');
}
function SelectDealerByName(name)
{
    return Bjax('/api/DealerCore/SelectDealerByName?name=', name, 'SP');
}
function SelectDealerByTellNoLike(tellNo)
{
    return Bjax('/api/DealerCore/SelectDealerByTellNoLike?tellNo=', tellNo, 'SP');
}
