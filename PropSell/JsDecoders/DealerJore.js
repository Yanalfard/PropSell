//---> int id
//---> string TellNo
//---> string Identification
//---> string Address
//---> string Name

{
    return Bjax('/api/DealerCore/AddDealer', dealer, 'LP');
}

{
    return Bjax('/api/DealerCore/DeleteDealer?id=', id, 'SP');
}

{
    var dealerLogId = new Array();
    dealerLogId.push(dealer);
    dealerLogId.push(logId);
    return Bjax('/api/DealerCore/UpdateDealer', dealerLogId, 'LP');
}

{
    return Bjax('/api/DealerCore/SelectAllDealers', '', 'G');
}

{
    return Bjax('/api/DealerCore/SelectDealerById?id=', id, 'SP');
}

{
    return Bjax('/api/DealerCore/SelectDealerByTellNo?tellNo=', tellNo, 'SP');
}

{
    return Bjax('/api/DealerCore/SelectDealerByIdentification?identification=', identification, 'SP');
}

{
    return Bjax('/api/DealerCore/SelectDealerByName?name=', name, 'SP');
}
